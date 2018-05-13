using LiveMedsData;
using LiveMedsData.Interfaces;
using LiveMedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService.Services
{
    class ProductService : IProductService
    {
        IProductDataAccess data;
        public ProductService(IProductDataAccess data)
        {
            this.data = data;
          
        }
        public IEnumerable<LiveMedsEntity.Product> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.Product Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Product value)
        {
            return this.data.Insert(value);
        }

        public int Update(LiveMedsEntity.Product value)
        {
            return this.data.Update(value);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
