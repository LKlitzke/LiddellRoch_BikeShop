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
    public class MarcaService : IMarcaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarcaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateMarca(Marca marca)
        {
            _unitOfWork.Marca.Add(marca);
            _unitOfWork.Save();
        }

        public void UpdateMarca(Marca marca)
        {
            _unitOfWork.Marca.Update(marca);
            _unitOfWork.Save();
        }

        public bool DeleteMarca(int id)
        {
            try
            {
                Marca marca = GetMarcaById(id);

                _unitOfWork.Marca.Remove(marca);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Marca GetMarcaById(int id)
        {
            return _unitOfWork.Marca.GetFirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Marca> GetAll()
        {
            return _unitOfWork.Marca.GetAll().ToList();
        }
    }
}
