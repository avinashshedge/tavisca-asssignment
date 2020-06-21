using System.Collections.Generic;

namespace Pizzaria.WebAPI.Model
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }

        public List<ItemType> ItemTypes { get; set; }

        public List<CustomizedIngredient> DefaultIngridient { get; set; }

    }
    
}
