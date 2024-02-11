using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LiddellRoch.Models.Tests
{
    public class BikeTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BikeTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void NomeMustBeRequired_ReturnsTrue()
        {
            // Arrange
            var propriedade = typeof(Bicicleta).GetProperty("Nome");

            // Act
            var isAttribRequired = propriedade.IsDefined(typeof(RequiredAttribute), true);

            // Assert
            Assert.True(isAttribRequired);
        }

        [Fact]
        public void DescricaoMustBeRequired_ReturnsTrue()
        {
            // Arrange
            var propriedade = typeof(Bicicleta).GetProperty("Descricao");

            // Act
            var isAttribRequired = propriedade.IsDefined(typeof(RequiredAttribute), true);

            // Assert
            Assert.True(isAttribRequired);
        }

        [Fact]
        public void PrecoHasRangeAttribute_ReturnsOK()
        {
            // Arrange
            var propriedade = typeof(Bicicleta).GetProperty("Preco");

            // Act
            var atributoRange = propriedade.GetCustomAttributes(typeof(RangeAttribute), true)[0] as RangeAttribute;

            // Assert
            Assert.NotNull(atributoRange);
            Assert.Equal(1, atributoRange.Minimum);
            Assert.Equal(1000000, atributoRange.Maximum);
        }

        [Fact]
        public void PesoHasRangeAttribute_ReturnsOK()
        {
            // Arrange
            var propriedade = typeof(Bicicleta).GetProperty("Peso");

            // Act
            var atributoRange = propriedade.GetCustomAttributes(typeof(RangeAttribute), true)[0] as RangeAttribute;

            // Assert
            Assert.NotNull(atributoRange);
            Assert.Equal(1.00, atributoRange.Minimum);
            Assert.Equal(50.00, atributoRange.Maximum);
        }

        // Teste para verificar se o atributo Range está definido corretamente para a propriedade Estoque
        [Fact]
        public void Estoque_Deve_Ter_Atributo_Range()
        {
            // Arrange
            var propriedade = typeof(Bicicleta).GetProperty("Estoque");

            // Act
            var atributoRange = propriedade.GetCustomAttributes(typeof(RangeAttribute), true)[0] as RangeAttribute;

            // Assert
            Assert.NotNull(atributoRange);
            Assert.Equal(1, atributoRange.Minimum);
            Assert.Equal(100, atributoRange.Maximum);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000001)]
        public void PrecoMustBeValidInRange_ReturnsOk(decimal preco)
        {
            // Arrange
            var bicicleta = new Bicicleta { Preco = preco };
            var validationContext = new ValidationContext(bicicleta);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(bicicleta, validationContext, validationResults);

            // Assert
            Assert.False(isValid);
        }
    }
}
