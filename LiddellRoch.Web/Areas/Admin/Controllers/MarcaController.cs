using AutoMapper;
using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MarcaController(IMarcaService marcaService, IWebHostEnvironment webHostEnvironment)
        {
            _marcaService = marcaService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var marcas = _marcaService.GetAll();
            return View(marcas);
        }

        public IActionResult Upsert(int? id)
        {
            Marca marca = new();

            if (id == null || id == 0)
            {
                return View(marca);
            }

            marca = _marcaService.GetMarcaById(id.Value);

            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        [HttpPost]
        public IActionResult Upsert(Marca obj, IFormFile? arquivo)
        {
            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    obj.CriadoEm = DateTime.Now;
                    _marcaService.CreateMarca(obj);
                    TempData["success"] = "Marca criada com sucesso!";
                }
                else
                {
                    _marcaService.UpdateMarca(obj);
                    TempData["success"] = "Marca atualizada com sucesso!";
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //public IActionResult Excluir(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Marca category = _marcaService.GetMarcaById(id.Value);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost, ActionName("Excluir")]
        //public IActionResult ExcluirPost(int? id)
        //{
        //    bool deleted = _marcaService.DeleteMarca(id.Value);
        //    if (deleted)
        //    {
        //        TempData["success"] = "Marca excluída com sucesso!";
        //    }
        //    else
        //    {
        //        TempData["error"] = "Erro ao excluir marca!";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Marca> marcas = _marcaService.GetAll().ToList();
            return Json(new { data = marcas });
        }

        public IActionResult Excluir(int id)
        {
            var marca = _marcaService.GetMarcaById(id);
            if (marca == null)
            {
                return Json(new { success = false, message = "Error ao excluir" });
            }

            _marcaService.DeleteMarca(id);

            return Json(new { success = true, message = "Exclusão com sucesso" });
        }
        #endregion
    }
}
