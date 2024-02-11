using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiddellRoch.Models.Tests
{
    public class CartTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CartTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void QuantidadeMustBeGreaterThanZero_ReturnsFalse()
        {
            // Arrange
            var carrinho = new CarrinhoCompras { Quantidade = 0 };

            // Act
            var isValid = carrinho.Quantidade > 0;

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void PrecoMustBeGreaterThanZero_ReturnsFalse()
        {
            // Arrange
            var carrinho = new CarrinhoCompras { Preco = -1 };

            // Act
            var isValid = carrinho.Preco > 0;

            // Assert
            Assert.False(isValid);
        }
    }
}
