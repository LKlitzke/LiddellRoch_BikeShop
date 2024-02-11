using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiddellRoch.Models.Tests
{
    public class UserTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void CreateUserWithMasks_ReturnsOk()
        {
            // Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Nome = "tester",
                Empresa = null,
                CodigoPostal = "29260000",
                Endereco = "RUA 12301920192",
                Cidade = "Sundays Martins",
                PhoneNumber = "12345678901"
            };

            // Act
            var propriedade = typeof(ApplicationUser).GetProperty("Nome");
            var isAttribRequired = propriedade.IsDefined(typeof(RequiredAttribute), true);

            // Assert
            Assert.Equal(8, user.CodigoPostal.Length);
            Assert.True(user.PhoneNumber.Length >= 11);
            Assert.True(user.Endereco.Length >= 10);
            Assert.True(isAttribRequired);
            Assert.Null(user.Empresa);
        }

        [Fact]
        public void LockUserAccess_ReturnsLockout()
        {
            // Arrange
            ApplicationUser user = new ApplicationUser()
            {
                Nome = "tester 2",
                CriadoEm = DateTime.Now
            };

            // Act
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddDays(30);

            // Assert
            Assert.True(user.LockoutEnabled);
        }
    }
}
