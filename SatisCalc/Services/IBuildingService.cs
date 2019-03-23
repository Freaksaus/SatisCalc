using SatisCalc.Models;
using System.Collections.Generic;

namespace SatisCalc.Services
{
    public interface IBuildingService
    {
        IEnumerable<Building> Get();
        Building Get(int id);
        bool Add(Building item);
        bool Update(Building item);
        bool Delete(int id);
    }
}
