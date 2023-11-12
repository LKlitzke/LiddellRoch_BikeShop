using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LiddellRoch.Application.Services.Interfaces
{
    public interface IMarcaService
    {
        Marca GetMarcaById(int id);
        IEnumerable<Marca> GetAll();
        void CreateMarca(Marca marca);
        void UpdateMarca(Marca marca);
        bool DeleteMarca(int id);
    }
}