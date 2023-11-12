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
                // setar imagem
                /*string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (arquivo != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.FileName);
                    string productPath = @"images\marcas\marca-" + obj.Id;
                    string finalPath = Path.Combine(wwwRootPath, productPath);

                    if (!Directory.Exists(finalPath))
                        Directory.CreateDirectory(finalPath);

                    using (var fileStream = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))
                    {
                        arquivo.CopyTo(fileStream);
                    }
                    obj.IconUrl = @"\" + productPath + @"\" + filename;

                    //ImagemProduto productImage = new()
                    //{
                    //    ImagemUrl = @"\" + productPath + @"\" + filename,
                    //    BicicletaId = obj.Id,
                    //};

                    //if (obj.Bicicleta.ImagensProduto == null)
                    //{
                    //    obj.Bicicleta.ImagensProduto = new List<ImagemProduto>();
                    //}

                    //obj.Bicicleta.ImagensProduto.Add(productImage);
                }*/
                obj.CriadoEm = DateTime.Now;

                if (obj.Id == 0)
                {
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

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Marca category = _marcaService.GetMarcaById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirPost(int? id)
        {
            bool deleted = _marcaService.DeleteMarca(id.Value);
            if (deleted)
            {
                TempData["success"] = "Marca excluída com sucesso!";
            }
            else
            {
                TempData["error"] = "Erro ao excluir marca!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
