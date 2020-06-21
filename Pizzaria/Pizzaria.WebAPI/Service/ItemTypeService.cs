using Pizzaria.WebAPI.DAL;
using Pizzaria.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.WebAPI.Service
{
    public class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeDal itemTypeDal;
        public ItemTypeService(IItemTypeDal _itemTypeDal)
        {
            itemTypeDal = _itemTypeDal;
        }
        public List<ItemType> GetItems()
        {
            return itemTypeDal.GetItems();
        }
    }
    public interface IItemTypeService
    {
        List<ItemType> GetItems();
    }
}
