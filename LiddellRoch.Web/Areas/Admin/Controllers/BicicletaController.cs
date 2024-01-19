using LiddellRoch.Application.DTOs;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class BicicletaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BicicletaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Bicicleta> bikes = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria,Marca").ToList();
            return View(bikes);
        }

        public IActionResult Upsert(int? id)
        {
            var coresEnumList = Enum.GetValues(typeof(Cores)).Cast<Cores>();
            var tamEnumList = Enum.GetValues(typeof(Tamanhos)).Cast<Tamanhos>();

            BicicletaVm bicicletaVm = new()
            {
                CategoriaList = _unitOfWork.Categoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Nome,
                    Value = u.Id.ToString()
                }).OrderBy(e => e.Text),

                MarcaList = _unitOfWork.Marca.GetAll().Select(marca => new SelectListItem
                {
                    Text = marca.Nome,
                    Value = marca.Id.ToString()
                }).OrderBy(e => e.Text),

                CoresListEnum = coresEnumList.Select(i => new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                }),

                TamanhosListEnum = tamEnumList.Select(i => new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                }),

                ComponentesList = Componentes.GetAll().Select(i => new SelectListItem
                {
                    Text = $"{i.Nome}",
                    Value = i.Id.ToString()
                }).OrderBy(e => e.Text),

                Bicicleta = new Bicicleta()
            };

            // Acertar isso aqui. Quando cria um novo registro, PRECISA ter uma row vazia para componente
            //bicicletaVm.Bicicleta.Componentes.Add(new Componente());

            

            // Create OR Update
            if (id != null && id != 0) {
                bicicletaVm.Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == id, includeProperties: "ImagensProduto,Componentes");
                bicicletaVm.TamanhosListSplit = bicicletaVm.Bicicleta.Tamanhos.Split(',').ToList();
                bicicletaVm.CoresListSplit = bicicletaVm.Bicicleta.Cores.Split(',').ToList();
            }

            if (bicicletaVm.Bicicleta.Componentes == null || bicicletaVm.Bicicleta.Componentes.Count == 0)
            {
                bicicletaVm.Bicicleta.Componentes = new List<Componente> { new Componente() { TipoComponenteId = 1, Valor = "", CriadoEm = DateTime.Now } };
            }
            return View(bicicletaVm);
        }

        [HttpPost]
        public IActionResult Upsert(BicicletaVm obj, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                obj.Bicicleta.Tamanhos = string.Join(",", obj.TamanhosListSplit);
                obj.Bicicleta.Cores = string.Join(",", obj.CoresListSplit);
                obj.Bicicleta.Componentes.ForEach(e => e.CriadoEm = DateTime.Now);
                obj.Bicicleta.Componentes.RemoveAll(e => e.Valor == null);

                var componentes = _unitOfWork.Componente.GetAll(u => u.BicicletaId == obj.Bicicleta.Id);
                _unitOfWork.Componente.RemoveRange(componentes);
                
                if (obj.Bicicleta.Id == 0)
                {
                    obj.Bicicleta.CriadoEm = DateTime.Now;
					_unitOfWork.Bicicleta.Add(obj.Bicicleta);
                }
                else
                {
                    _unitOfWork.Bicicleta.Update(obj.Bicicleta);
                }
                _unitOfWork.Save();

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = @"images\bicicletas\bicicleta-" + obj.Bicicleta.Id;
                        string finalPath = Path.Combine(wwwRootPath, productPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        ImagemProduto productImage = new()
                        {
                            ImagemUrl = @"\" + productPath + @"\" + filename,
                            BicicletaId = obj.Bicicleta.Id,
                        };

                        if (obj.Bicicleta.ImagensProduto == null)
                        {
                            obj.Bicicleta.ImagensProduto = new List<ImagemProduto>();
                        }

                        obj.Bicicleta.ImagensProduto.Add(productImage);
                    }

                    _unitOfWork.Bicicleta.Update(obj.Bicicleta);
                    _unitOfWork.Save();
                }
                TempData["success"] = "Bicicleta criado/atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoriaList = _unitOfWork.Categoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Nome,
                    Value = u.Id.ToString()
                }).OrderBy(e => e.Text);
                return View(obj);
            }
        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.ImagemProduto.GetFirstOrDefault(u => u.Id == imageId);
            int bikeId = imageToBeDeleted.BicicletaId;

            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImagemUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImagemUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.ImagemProduto.Remove(imageToBeDeleted);
                _unitOfWork.Save();

                TempData["success"] = "Exclusão com sucesso";
            }

            return RedirectToAction(nameof(Upsert), new { id = bikeId });
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Bicicleta> bikes = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria,Marca").ToList();
            return Json(new { data = bikes });
        }

        public IActionResult Delete(int? id)
        {
            var product = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Erro ao excluir" });
            }

            string productPath = @"images\bicicletas\bicicleta-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }
            Directory.CreateDirectory(finalPath);

            _unitOfWork.Bicicleta.Remove(product);
            _unitOfWork.Save();

            List<Bicicleta> bikes = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria").ToList();
            return Json(new { success = true, message = "Exclusão com sucesso" });
        }
        #endregion
    }
}
