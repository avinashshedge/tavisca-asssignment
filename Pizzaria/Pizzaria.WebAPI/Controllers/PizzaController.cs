using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.WebAPI.Model;
using Pizzaria.WebAPI.Service;
using Pizzaria.WebAPI.Service.Interface;

namespace Pizzaria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        private readonly ICustomizedIngredientService customizedIngredientService;
        private readonly IItemTypeService itemTypeService;
        private readonly IIngredientService ingredientService;
        public PizzaController(IPizzaService _pizzaService, IIngredientService _ingredientService,
            IItemTypeService _itemTypeService, ICustomizedIngredientService _customizedIngredientService)
        {
            pizzaService = _pizzaService;
            customizedIngredientService = _customizedIngredientService;
            itemTypeService = _itemTypeService;
            ingredientService = _ingredientService;
        }

        [HttpGet]
        public IActionResult GetAllPizza()
        {
            var pizza = pizzaService.GetAllPizza();
            return Ok(pizza);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var pizzaVM = new PizzaVM();
            if (id > 0)
            {
                pizzaVM.Pizza = pizzaService.GetPizzaById(id);
                pizzaVM.DefaultIngridient = customizedIngredientService.GetCustomizedIngredientsById(id);
            }
            else
            {
                pizzaVM.Pizza = GetDefaultPizza();
                pizzaVM.DefaultIngridient = new List<CustomizedIngredient>();
            }
            pizzaVM.ItemTypes = itemTypeService.GetItems();

            return Ok(pizzaVM);
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            if(pizza == null)
            {
                return BadRequest();
            }

            var orderId = pizzaService.AddPizza(pizza);
            return Ok(orderId);
        }

        [HttpGet, Route("pizza-ingredients")]
        public IEnumerable<Ingredient> GetIngredient()
        {
            return ingredientService.GetIngredients();
        }

        #region Private Methods
        
        private Pizza GetDefaultPizza()
        {
            return new Pizza()
            {
                Id = 0,
                Baseprice = 200,
                ImageUrl = "",
                Name = "Custom Pizza",
                Type = "non-veg"               
            };
        }
        #endregion
    }
}