using Pizzaria.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.WebAPI.DAL
{
    public class PizzaDal: IPizzaDal
    {
        private static List<Pizza> GetPizzas()
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

        public Guid AddPizza(Pizza pizza)
        {
            var orderId = Guid.NewGuid();
            //logic to add pizza to file

            return orderId;
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return GetPizzas();
        }

        public Pizza GetPizzaById(int id)
        {
            return GetPizzas().FirstOrDefault(i => i.Id == id);
        }
    }

    public interface IPizzaDal
    {
        Guid AddPizza(Pizza pizza);

        Pizza GetPizzaById(int id);

        IEnumerable<Pizza> GetAllPizza();

    }
}
