using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.Service
{
    public class IngredientService: IIngredientService
    {
        private readonly IIngredientDal ingredientDal;
        public IngredientService(IIngredientDal _ingredientDal)
        {
            ingredientDal = _ingredientDal;
        }
        public List<Ingredient> GetIngredients()
        {
            return ingredientDal.GetIngredients();
        }
        
    }
    public interface IIngredientService
    {
        List<Ingredient> GetIngredients();
    }
}
