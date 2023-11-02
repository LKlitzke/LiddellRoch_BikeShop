using LiddellRoch.DataAccess.Data;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            // Roda migrations se não forem aplicadas
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // ?
            }

            // Cria roles se não existirem (Executa uma vez apenas)
            if (!_roleManager.RoleExistsAsync(SD.Role_Cliente).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Cliente)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Administrador)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Empregado)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Empresa)).GetAwaiter().GetResult();

                // Cria um ApplicationUser Administrador
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Administrador@gmail.com",
                    Email = "Administrador@gmail.com",
                    Nome = "Administrador",
                    PhoneNumber = "1234567890",
                    Endereco = "Martin Luther",
                    Estado = "ES",
                    EmailConfirmed = true,
                    CodigoPostal = "12345",
                    Cidade = "Sundays Martins"
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user1 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Administrador@gmail.com");
                _userManager.AddToRoleAsync(user1, SD.Role_Administrador).GetAwaiter().GetResult();

                // Cria um ApplicationUser Company
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Company@gmail.com",
                    Email = "Company@gmail.com",
                    Nome = "Company",
                    PhoneNumber = "0987654321",
                    Endereco = "Chunga Bunga",
                    Estado = "MG",
                    EmailConfirmed = true,
                    CodigoPostal = "54321",
                    Cidade = "Victory"
                }, "Company123*").GetAwaiter().GetResult();

                ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Company@gmail.com");
                _userManager.AddToRoleAsync(user2, SD.Role_Empresa).GetAwaiter().GetResult();

                // Cria um ApplicationUser Employee
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Employee@gmail.com",
                    Email = "Employee@gmail.com",
                    Nome = "Employee",
                    PhoneNumber = "0192837465",
                    Endereco = "HomeOffice",
                    Estado = "AC",
                    EmailConfirmed = true,
                    CodigoPostal = "67890",
                    Cidade = "Old Village"
                }, "Employee123*").GetAwaiter().GetResult();

                ApplicationUser user3 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Employee@gmail.com");
                _userManager.AddToRoleAsync(user3, SD.Role_Empregado).GetAwaiter().GetResult();

                // Cria um ApplicationUser Employee
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Customer@gmail.com",
                    Email = "Customer@gmail.com",
                    Nome = "Customer",
                    PhoneNumber = "5647382910",
                    Endereco = "Miami",
                    Estado = "FL",
                    EmailConfirmed = true,
                    CodigoPostal = "09876",
                    Cidade = "Saw"
                }, "Customer123*").GetAwaiter().GetResult();

                ApplicationUser user4 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Customer@gmail.com");
                _userManager.AddToRoleAsync(user4, SD.Role_Cliente).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
