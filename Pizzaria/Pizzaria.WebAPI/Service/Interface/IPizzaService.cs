using Pizzaria.WebAPI.Model;
using System;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.Service.Interface
{
    public interface IPizzaService
    {
        Guid AddPizza(Pizza pizza);
        Pizza GetPizzaById(int id);
        IEnumerable<Pizza> GetAllPizza();
    }
}
