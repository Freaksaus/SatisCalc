using System;
using System.Collections.Generic;
using System.Linq;


namespace SatisCalc.Services
{
    public class ItemService : IItemService
    {
        private Data.Models.SatisContext db;
        public ItemService(Data.Models.SatisContext db)
        {
            this.db = db;
        }

        public bool Add(SatisCalc.Models.Item model)
        {
            var record = new Data.Models.Item()
            {
                Category = model.Category,
                Name = model.Name,
            };

            db.Items.Add(record);
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var record = db.Items.Where(i => i.Id == id).SingleOrDefault();
            if(record == null)
            {
                return true;
            }

            db.Items.Remove(record);
            db.SaveChanges();

            return true;
        }

        public IEnumerable<SatisCalc.Models.Item> Get()
        {
            var models = new List<SatisCalc.Models.Item>();
            foreach (var record in db.Items)
            {
                var model = MapItem(record);
                models.Add(model);
            }

            return models;
        }

        public SatisCalc.Models.Item Get(int id)
        {
            var record = db.Items.Where(i => i.Id == id).SingleOrDefault();
            if(record == null)
            {
                return null;
            }

            return MapItem(record);
        }

        public bool Update(SatisCalc.Models.Item model)
        {
            if(model == null)
            {
                throw new Exception("Item is null");
            }

            var record = db.Items.Where(i => i.Id == model.Id).SingleOrDefault();
            if(record == null)
            {
                throw new Exception($"Item with id: {model.Id} not found");
            }

            record.Category = model.Category;
            record.Name = model.Name;
            db.SaveChanges();

            return true;
        }

        private SatisCalc.Models.Item MapItem(Data.Models.Item record)
        {
            var item = new SatisCalc.Models.Item()
            {
                Category = record.Category,
                Id = record.Id,
                Name = record.Name,
            };

            return item;
        }
    }
}
