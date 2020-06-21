using System.Collections.Generic;

namespace Pizzaria.WebAPI.Model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public int Baseprice { get; set; }

        public ItemType PizzaSize { get; set; }

        public ItemType CrushType { get; set; }

        public List<CustomizedIngredient> DefaultIngredients { get; set; }

    }
}
