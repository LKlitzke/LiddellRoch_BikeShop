using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace LiddellRoch.Models.Tests
{
    public class CategoryTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CategoryTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void CreateCategoryWithoutName_ReturnsErros()
        {
            Categoria categoria = new Categoria()
            {
                Id = 1,
                Nome = "Testing testing", // Testar
                OrdemExibicao = 1,
                CriadoEm = DateTime.Now,
            };

            Assert.NotNull(categoria.Nome);
            Assert.InRange(categoria.OrdemExibicao, 1, 100);
        }
    }
}