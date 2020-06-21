using Pizzaria.WebAPI.Model;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.DAL
{
    public class IngredientDal : IIngredientDal
    {
        public List<Ingredient> GetIngredients()
        {           
            return new List<Ingredient>()
            {
                //Ingridient as type = 1
                new Ingredient(){ Id =1,Name="Extra Cheese",Price=50,Type=1 },

                //Ingridient as type = 2
                new Ingredient(){ Id =2,Name="Tomato",Price=30,Type=2 },
                new Ingredient(){ Id =3,Name="Onion",Price=40,Type=2 },
                new Ingredient(){ Id =4,Name="Capsicum",Price=30,Type=2 },
                new Ingredient(){ Id =5,Name="Paneer",Price=60,Type=2 },
                new Ingredient(){ Id =6,Name="Chicken",Price=80,Type=2 },
                new Ingredient(){ Id =7,Name="Baby Corn",Price=40,Type=2 },
                new Ingredient(){ Id =8,Name="Mushrooms",Price=35,Type=2 },

                //Toppings as type = 3
                new Ingredient(){ Id =9,Name="Golden Olive",Price=30,Type=3 },
                new Ingredient(){ Id =10,Name="Extra Onion",Price=20,Type=3 },
                new Ingredient(){ Id =11,Name="Jalapeno",Price=40,Type=3 },
                new Ingredient(){ Id =12,Name="Peri Peri Chicken",Price=59,Type=3 },
                new Ingredient(){ Id =13,Name="Extra Chicken",Price=55,Type=3 },
                new Ingredient(){ Id =14,Name="Extra Paneer",Price=45,Type=3 }
            };
        }
    }

    public interface IIngredientDal
    {
        List<Ingredient> GetIngredients();
    }
}
