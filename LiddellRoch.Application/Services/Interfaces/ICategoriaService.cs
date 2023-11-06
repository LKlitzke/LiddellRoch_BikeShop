using LiddellRoch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LiddellRoch.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Categoria GetCategoryById(int id);
        IEnumerable<Categoria> GetAll();
        void CreateCategory(Categoria categoria);
        void UpdateCategory(Categoria categoria);
        bool DeleteCategory(int id);
    }
}