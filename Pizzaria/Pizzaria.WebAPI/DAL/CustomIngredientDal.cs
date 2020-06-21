using Pizzaria.WebAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.WebAPI.DAL
{
    public class CustomIngredientDal : ICustomIngredientDal
    {
        public List<CustomizedIngredient> GetCustomizedIngredientsById(int id)
        {
            return GetCustomItems().Where(i => i.PizzaId == id).ToList();
        }

        private List<CustomizedIngredient> GetCustomItems()
        {
            return new List<CustomizedIngredient>()
            {
                new CustomizedIngredient(){ Id =1,PizzaId=1,IngredientId=2},
                new CustomizedIngredient(){ Id =2,PizzaId=1,IngredientId=3},
                new CustomizedIngredient(){ Id =3,PizzaId=2,IngredientId=2},
                new CustomizedIngredient(){ Id =4,PizzaId=2,IngredientId=3},
                new CustomizedIngredient(){ Id =5,PizzaId=2,IngredientId=4},
                new CustomizedIngredient(){ Id =6,PizzaId=3,IngredientId=2},
                new CustomizedIngredient(){ Id =7,PizzaId=4,IngredientId=2},
                new CustomizedIngredient(){ Id =8,PizzaId=4,IngredientId=5},
                new CustomizedIngredient(){ Id =9,PizzaId=5,IngredientId=3},
                new CustomizedIngredient(){ Id =10,PizzaId=5,IngredientId=6},

                //gridient as type = 2
                //new Ingredient(){ Id =2,Name="Tomato",Price=30,Type=2 },
                //new Ingredient(){ Id =3,Name="Onion",Price=40,Type=2 },
                //new Ingredient(){ Id =4,Name="Capsicum",Price=30,Type=2 },
                //new Ingredient(){ Id =5,Name="Paneer",Price=60,Type=2 },
                //new Ingredient(){ Id =6,Name="Chicken",Price=80,Type=2 },
                //new Ingredient(){ Id =7,Name="Baby Corn",Price=40,Type=2 },
                //new Ingredient(){ Id =8,Name="Mushrooms",Price=35,Type=2 },
            };
        }

    }

    public interface ICustomIngredientDal
    {
        List<CustomizedIngredient> GetCustomizedIngredientsById(int id);
    }

}
