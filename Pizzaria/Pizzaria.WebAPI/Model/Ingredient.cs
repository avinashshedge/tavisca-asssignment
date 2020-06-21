namespace Pizzaria.WebAPI.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }
        public string ImageUrl { get; set; }
    }
   
}
