using Moq;
using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using Pizzaria.WebAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1.Service
{
    public class PizzaServiceTest
    {
        private PizzaService _service;
        private Mock<IPizzaDal> pizzaDalMock;

        private static List<Pizza> GetStaticPizza()
        {
            return new List<Pizza>() {
                 new Pizza(){
                            Id =1,Name="Paneer Pizza",Baseprice = 250,ImageUrl="https://images.dominos.co.in/new_margherita_2502.jpg",Type="veg"
                        },

                new Pizza(){
                            Id =2,Name="Chicken Pizza",Baseprice = 250,ImageUrl="https://images.dominos.co.in/new_peppy_paneer.jpg",Type="non-veg"
                        },
                 new Pizza(){
                            Id =3,Name="BBQ Chicken Pizza",Baseprice = 220,ImageUrl="https://images.dominos.co.in/new_pepper_barbeque_chicken.jpg",Type="non-veg"
                        },
                  new Pizza(){
                            Id =4,Name="Mushrooms Mix Veg Pizza",Baseprice = 270,ImageUrl="https://images.dominos.co.in/farmhouse.png",Type="veg"
                        },
                  new Pizza(){
                            Id =5,Name="Spicy Chicken Pizza",Baseprice = 300,ImageUrl="https://images.dominos.co.in/new_pepper_barbeque_chicken.jpg",Type="non-veg"
                        }
                };

        }

        private void SetupMocks()
        {
            pizzaDalMock = new Mock<IPizzaDal>();
            pizzaDalMock.Setup(i => i.GetAllPizza()).Returns(GetStaticPizza());
            _service = new PizzaService(pizzaDalMock.Object);

        }

        [Fact]
        public void GetPizzas_Returns_Data()
        {
            SetupMocks();

            // Act
            var result = _service.GetAllPizza();

            // Assert
            Assert.True(result.Count() > 0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetPizzasById_Returns_Data(int id)
        {
            pizzaDalMock = new Mock<IPizzaDal>();
            pizzaDalMock.Setup(i => i.GetPizzaById(id)).Returns(GetStaticPizza().FirstOrDefault());
            _service = new PizzaService(pizzaDalMock.Object);


            // Act
            var result = _service.GetPizzaById(id);

            // Assert
            Assert.NotNull(result);
        }

        private Pizza CustomPizza()
        {
            var pizza = new Pizza()
            {
                Id = 0,
                Name = "Custom Pizza",
                ImageUrl = "",
                Type = "veg",
                Baseprice =100
            };
            pizza.DefaultIngredients = new List<CustomizedIngredient>()
            {
                new CustomizedIngredient(){IngredientId = 1},
                new CustomizedIngredient(){IngredientId = 2}
            };

            return pizza;
        }

        [Fact]
        public void AddCustomPizza_Returns_Data()
        {

            var pizza = CustomPizza();
            pizzaDalMock = new Mock<IPizzaDal>();
            pizzaDalMock.Setup(i => i.AddPizza(pizza)).Returns(Guid.NewGuid);
            _service = new PizzaService(pizzaDalMock.Object);
            // Act
            var result = _service.AddPizza(pizza);

            // Assert
            Assert.NotNull(result);
        }
    }
}
