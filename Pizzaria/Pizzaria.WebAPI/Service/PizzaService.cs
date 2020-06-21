using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using Pizzaria.WebAPI.Service.Interface;
using System;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.Service
{
    public class PizzaService:IPizzaService
    {
        private readonly IPizzaDal pizzaDal;
        public PizzaService(IPizzaDal _pizzaDal)
        {
            pizzaDal = _pizzaDal;
        }

        public Guid AddPizza(Pizza pizza)
        {
            return pizzaDal.AddPizza(pizza);
        }

        public Pizza GetPizzaById(int id)
        {
            return pizzaDal.GetPizzaById(id);
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return pizzaDal.GetAllPizza();
        }

      
    }
}
