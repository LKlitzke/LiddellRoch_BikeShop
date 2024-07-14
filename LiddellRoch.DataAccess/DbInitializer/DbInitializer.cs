using LiddellRoch.DataAccess.Data;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiddellRoch.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            //Roda migrations se não forem aplicadas
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
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
                    UserName = "Administrador",
                    Email = "Administrador@gmail.com",
                    Nome = "Administrador",
                    PhoneNumber = "1234567890",
                    Endereco = "Rua Martin Luther",
                    Estado = "ES",
                    EmailConfirmed = true,
                    CodigoPostal = "29260-000",
                    CriadoEm = DateTime.Now,
                    Cidade = "Sundays Martins",
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user1 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Administrador@gmail.com");
                _userManager.AddToRoleAsync(user1, SD.Role_Administrador).GetAwaiter().GetResult();


                // Cria um ApplicationUser Empresa
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Empresa",
                    Email = "Empresa@gmail.com",
                    Nome = "Empresa",
                    PhoneNumber = "0987654321",
                    Endereco = "Av. Fernando Ferrari",
                    EmpresaId = 1,
                    Estado = "ES",
                    EmailConfirmed = true,
                    CodigoPostal = "29255-000",
                    CriadoEm = DateTime.Now,
                    Cidade = "Victory"
                }, "Empresa123*").GetAwaiter().GetResult();

                ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Empresa@gmail.com");
                _userManager.AddToRoleAsync(user2, SD.Role_Empresa).GetAwaiter().GetResult();

                // Cria um ApplicationUser Empregado
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Empregado",
                    Email = "Empregado@gmail.com",
                    Nome = "Empregado",
                    PhoneNumber = "0192837465",
                    Endereco = "Av. Praia da Costa",
                    Estado = "ES",
                    EmailConfirmed = true,
                    CodigoPostal = "67890-000",
                    CriadoEm = DateTime.Now,
                    Cidade = "Old Village"
                }, "Empregado123*").GetAwaiter().GetResult();

                ApplicationUser user3 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Empregado@gmail.com");
                _userManager.AddToRoleAsync(user3, SD.Role_Empregado).GetAwaiter().GetResult();

                // Cria um ApplicationUser Cliente
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "ClienteTester",
                    Email = "ClienteTester@gmail.com",
                    Nome = "ClienteTester",
                    PhoneNumber = "5647382910",
                    Endereco = "Miami",
                    Estado = "FL",
                    EmailConfirmed = true,
                    CodigoPostal = "09876",
                    CriadoEm = DateTime.Now,
                    Cidade = "Saw"
                }, "Cliente123*").GetAwaiter().GetResult();

                ApplicationUser user4 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "ClienteTester@gmail.com");
                _userManager.AddToRoleAsync(user4, SD.Role_Cliente).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
