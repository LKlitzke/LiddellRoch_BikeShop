using AutoMapper;
using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var categorias = _categoriaService.GetAll();

            //var categoryDTOs = _mapper.Map<List<Categoria>>(categorias);
            return View(categorias);
        }

        public IActionResult Upsert(int? id)
        {
            Categoria categoria = new();

            if (id == null || id == 0)
            {
                return View(categoria);
            }

            categoria = _categoriaService.GetCategoryById(id.Value);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Upsert(Categoria obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    obj.CriadoEm = DateTime.Now;
                    _categoriaService.CreateCategory(obj);
                    TempData["success"] = "Categoria criada com sucesso!";
                }
                else
                {
                    _categoriaService.UpdateCategory(obj);
                    TempData["success"] = "Categoria atualizada com sucesso!";
                }
               
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categoria category = _categoriaService.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirPost(int? id)
        {
            bool deleted = _categoriaService.DeleteCategory(id.Value);
            if (deleted)
            {
                TempData["success"] = "Categoria excluída com sucesso!";
            }
            else
            {
                TempData["error"] = "Erro ao excluir categoria!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
