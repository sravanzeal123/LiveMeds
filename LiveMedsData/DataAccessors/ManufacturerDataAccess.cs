using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class ManufacturerDataAccess : IManufacturerDataAccess
    {
        LiveMedsDBContext context;
        public ManufacturerDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }
        public IEnumerable<LiveMedsEntity.Manufacturer> GetAll()
        {
            return this.context.Manufactureres.ToList();
      
        }
        public LiveMedsEntity.Manufacturer Get(int id)
        {
           return this.context.Manufactureres.SingleOrDefault(mn => mn.ManufacturerId == id);
            
        }
        public int Insert(LiveMedsEntity.Manufacturer value)
        {
            this.context.Manufactureres.Add(value);
            return this.context.SaveChanges();
        }
        public int Update(LiveMedsEntity.Manufacturer value)
        {
            LiveMedsEntity.Manufacturer mn = this.context.Manufactureres.SingleOrDefault(m => m.ManufacturerId== value.ManufacturerId);
            mn.ManufactureName = value.ManufactureName;
            mn.Products = mn.Products;
            return this.context.SaveChanges();
        }
        public int Delete(int id)
        {
            LiveMedsEntity.Manufacturer mn = this.context.Manufactureres.SingleOrDefault(m => m.ManufacturerId == id);
            this.context.Manufactureres.Remove(mn);
            return this.context.SaveChanges();
        }
    }
}
