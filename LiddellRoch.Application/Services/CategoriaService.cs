using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(Categoria categoria)
        {
            _unitOfWork.Categoria.Add(categoria);
            _unitOfWork.Save();
        }
        public void UpdateCategory(Categoria categoria)
        {
            _unitOfWork.Categoria.Update(categoria);
            _unitOfWork.Save();
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                Categoria categoria = GetCategoryById(id);

                _unitOfWork.Categoria.Remove(categoria);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Categoria GetCategoryById(int id)
        {
            return _unitOfWork.Categoria.GetFirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _unitOfWork.Categoria.GetAll().ToList();
        }
    }
}
