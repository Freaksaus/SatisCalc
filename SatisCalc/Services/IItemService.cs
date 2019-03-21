using SatisCalc.Models;
using System.Collections.Generic;

namespace SatisCalc.Services
{
    public interface IItemService
    {
        IEnumerable<Item> Get();
        Item Get(int id);
        bool Add(Item item);
        bool Update(Item item);
        bool Delete(int id);
    }
}
