using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GerenciarRoles(string userId)
        {
            var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId, includeProperties: "Empresa");
            IEnumerable<SelectListItem> rolesList = _roleManager.Roles.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name
            });

            IEnumerable<SelectListItem> empresasList = _unitOfWork.Empresa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Nome,
                Value = u.Id.ToString()
            });

            RoleManagementVm roleVm = new()
            {
                ApplicationUser = user,
                RoleList = rolesList,
                EmpresaList = empresasList
            };
            roleVm.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId))
                .GetAwaiter().GetResult().FirstOrDefault();

            return View(roleVm);
        }

        [HttpPost]
        public IActionResult GerenciarRoles(RoleManagementVm roleVm)
        {
            var roleAnterior = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == roleVm.ApplicationUser.Id))
                .GetAwaiter().GetResult().FirstOrDefault();

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == roleVm.ApplicationUser.Id);
            if (!(roleVm.ApplicationUser.Role == roleAnterior))
            {
                // Atualiza role
                if (roleVm.ApplicationUser.Role == SD.Role_Empresa)
                {
                    applicationUser.EmpresaId = roleVm.ApplicationUser.EmpresaId;
                }
                if (roleAnterior == SD.Role_Empresa)
                {
                    applicationUser.EmpresaId = null;
                }
                _unitOfWork.ApplicationUser.Update(applicationUser);
                _unitOfWork.Save();
                _userManager.RemoveFromRoleAsync(applicationUser, roleAnterior).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleVm.ApplicationUser.Role).GetAwaiter().GetResult();
            }
            else
            {
                if (roleAnterior == SD.Role_Empresa && applicationUser.EmpresaId != roleVm.ApplicationUser.EmpresaId)
                {
                    applicationUser.EmpresaId = roleVm.ApplicationUser.EmpresaId;
                    _unitOfWork.ApplicationUser.Update(applicationUser);
                    _unitOfWork.Save();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GerenciarClaims(string userId)
        {
            var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            var userClaimsDb = _userManager.GetClaimsAsync(user).GetAwaiter().GetResult();

            var claimModel = new UserClaimsVm()
            {
                UserId = userId
            };
            foreach (Claim claim in SD.ClaimList)
            {
                UserClaim userClaim = new ()
                {
                    ClaimType = claim.Type
                };
                if (userClaimsDb.Any(u => u.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }
                claimModel.Claims.Add(userClaim);
            }
            return View(claimModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClaimManagement(UserClaimsVm userClaimsVm)
        {
            var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userClaimsVm.UserId, tracked: true);
            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<Claim> userClaimsDb = _userManager.GetClaimsAsync(user).GetAwaiter().GetResult();
            var result = _userManager.RemoveClaimsAsync(user, userClaimsDb).GetAwaiter().GetResult();

            result = _userManager.AddClaimsAsync(user,
                userClaimsVm.Claims.Where(u => u.IsSelected)
                .Select(x => new Claim(x.ClaimType, x.IsSelected.ToString()))
            ).GetAwaiter().GetResult();
            TempData["success"] = "Claims atualizados com sucesso!";

            return RedirectToAction("Index");
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> users = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Empresa").ToList();

            foreach (var user in users)
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                user.Empresa ??= new() { Nome = "" };
            }
            return Json(new { data = users });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Json(new { success = false, message = "Erro ao bloquear/desbloquear" });
            }

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                // Unlocks user
                user.LockoutEnd = DateTime.Now;

            }
            else
            {
                // Locks user for one year
                user.LockoutEnd = DateTime.Now.AddYears(1);
            }
            _unitOfWork.ApplicationUser.Update(user);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Bloqueio/Desbloqueio com sucesso!" });
        }

        public IActionResult Delete(string userId)
        {
            var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);

            if (user.Email == HttpContext.User.Identity.Name)
            {
                return Json(new { success = false, message = "Não é possível excluir seu próprio login" });
            }

            _unitOfWork.ApplicationUser.Remove(user);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Exclusão com sucesso" });
        }
        #endregion
    }
}
