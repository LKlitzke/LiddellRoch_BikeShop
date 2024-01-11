using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class EmpresaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmpresaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Empresa> empresas = _unitOfWork.Empresa.GetAll().ToList();
            return View(empresas);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Criar
                return View(new Empresa());

            }
            else
            {
                // Atualizar
                Empresa empresa = _unitOfWork.Empresa.GetFirstOrDefault(u => u.Id == id);
                return View(empresa);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Empresa obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    obj.CriadoEm = DateTime.Now;
                    _unitOfWork.Empresa.Add(obj);
                }
                else
                {
                    _unitOfWork.Empresa.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Empresa atualizada com sucesso!";
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Empresa> Companys = _unitOfWork.Empresa.GetAll().ToList();
            return Json(new { data = Companys });
        }

        public IActionResult Excluir(int? id)
        {
            var Company = _unitOfWork.Empresa.GetFirstOrDefault(u => u.Id == id);
            if (Company == null)
            {
                return Json(new { success = false, message = "Error ao excluir" });
            }

            _unitOfWork.Empresa.Remove(Company);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Exclusão com sucesso" });
        }
        #endregion

    }
}
