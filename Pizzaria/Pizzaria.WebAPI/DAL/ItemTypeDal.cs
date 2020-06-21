using Pizzaria.WebAPI.Model;
using System.Collections.Generic;

namespace Pizzaria.WebAPI.DAL
{
    public class ItemTypeDal : IItemTypeDal
    {
        public List<ItemType> GetItems()
        {
            return new List<ItemType>()
            {
                new ItemType(){ Id =1,Name="Small",Price=80 ,Type= 1},
                new ItemType(){ Id =1,Name="Regular",Price=100 ,Type= 1},
                new ItemType(){ Id =1,Name="Large",Price=120,Type= 1},

                new ItemType(){ Id =1,Name="Thin",Price=100 ,Type= 2},
                new ItemType(){ Id =1,Name="Hand",Price=80 ,Type= 2},
                new ItemType(){ Id =1,Name="Pan",Price=60 ,Type= 2}
            };
        }
    }

    public interface IItemTypeDal
    {
        List<ItemType> GetItems();
    }
}
