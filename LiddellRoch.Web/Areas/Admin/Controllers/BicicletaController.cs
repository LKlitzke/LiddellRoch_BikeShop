﻿using LiddellRoch.DataAccess.Repository.Interfaces;
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
            List<Bicicleta> bikes = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria").ToList();
            return View(bikes);
        }

        public IActionResult Upsert(int? id)
        {
            BicicletaVm bicicletaVm = new()
            {
                CategoriaList = _unitOfWork.Categoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Nome,
                    Value = u.Id.ToString()
                }),
                Bicicleta = new Bicicleta()
            };

            // Create OR Update
            if (id == null || id == 0)
                return View(bicicletaVm);
            else
            {
                bicicletaVm.Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == id, includeProperties: "ImagensProduto");
                return View(bicicletaVm);
            }
        }

        [HttpPost]
        public IActionResult Upsert(BicicletaVm obj, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                if (obj.Bicicleta.Id == 0)
                {
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
                        string productPath = @"images\products\product-" + obj.Bicicleta.Id;
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
                });
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

            string productPath = @"images\products\product-" + id;
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