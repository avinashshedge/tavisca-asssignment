using Moq;
using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using Pizzaria.WebAPI.Service;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class IngredientServiceTest
    {
        private IngredientService _service;
        private Mock<IIngredientDal> ingredientDalMock;        

        private static List<Ingredient> GetStaticIngredients()
        {
            return new List<Ingredient>() {
                new Ingredient(){Id=0,Name="Pepsi",Price=80}
                };
            
        }

        private void SetupMocks()
        {
            ingredientDalMock = new Mock<IIngredientDal>();
            ingredientDalMock.Setup(i => i.GetIngredients()).Returns(GetStaticIngredients());
            _service = new IngredientService(ingredientDalMock.Object);

        }

        [Fact]
        public void GetIngredients_Returns_Data()
        {
            SetupMocks();
            
            // Act
            var service = _service.GetIngredients();

            // Assert
            Assert.True(service.Count > 0);
        }
    }
}
