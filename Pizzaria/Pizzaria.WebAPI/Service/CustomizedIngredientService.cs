using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.Service
{
    public class CustomizedIngredientService : ICustomizedIngredientService
    {
        private readonly ICustomIngredientDal customIngredientDal;
        public CustomizedIngredientService(ICustomIngredientDal _customIngredientDal)
        {
            customIngredientDal = _customIngredientDal;
        }
        public List<CustomizedIngredient> GetCustomizedIngredientsById(int id)
        {
            return customIngredientDal.GetCustomizedIngredientsById(id);
        }
    }

    public interface ICustomizedIngredientService
    {
        List<CustomizedIngredient> GetCustomizedIngredientsById(int id);
    }
}
