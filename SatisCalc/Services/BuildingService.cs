using System;
using System.Collections.Generic;
using System.Linq;


namespace SatisCalc.Services
{
    public class BuildingService : IBuildingService
    {
        private Data.Models.SatisContext db;
        public BuildingService(Data.Models.SatisContext db)
        {
            this.db = db;
        }

        public bool Add(SatisCalc.Models.Building model)
        {
            var record = new Data.Models.Building()
            {
                Name = model.Name,
            };

            db.Buildings.Add(record);
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var record = db.Buildings.Where(i => i.BuildingId == id).SingleOrDefault();
            if(record == null)
            {
                return true;
            }

            db.Buildings.Remove(record);
            db.SaveChanges();

            return true;
        }

        public IEnumerable<SatisCalc.Models.Building> Get()
        {
            var models = new List<SatisCalc.Models.Building>();
            foreach (var record in db.Buildings)
            {
                var model = MapBuilding(record);
                models.Add(model);
            }

            return models;
        }

        public SatisCalc.Models.Building Get(int id)
        {
            var record = db.Buildings.Where(i => i.BuildingId == id).SingleOrDefault();
            if(record == null)
            {
                return null;
            }

            return MapBuilding(record);
        }

        public bool Update(SatisCalc.Models.Building model)
        {
            if(model == null)
            {
                throw new Exception("Building is null");
            }

            var record = db.Buildings.Where(i => i.BuildingId == model.Id).SingleOrDefault();
            if(record == null)
            {
                throw new Exception($"Building with id: {model.Id} not found");
            }

            record.Name = model.Name;
            db.SaveChanges();

            return true;
        }

        private SatisCalc.Models.Building MapBuilding(Data.Models.Building record)
        {
            var model = new SatisCalc.Models.Building()
            {
                Id = record.BuildingId,
                Name = record.Name,
            };

            return model;
        }
    }
}
