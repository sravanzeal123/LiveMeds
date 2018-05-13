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
    class OrderService : IOrderService
    {
        IOrderDataAccess data;

        public OrderService ( IOrderDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<LiveMedsEntity.Order> GetAll(string type)
        {
            return this.data.GetAll(type);
        }

        public LiveMedsEntity.Order Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Order value)
        {
            return this.data.Insert(value);
        }

        public int Update(LiveMedsEntity.Order value)
        {
            return this.data.Update(value);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id); 
        }
    }
}
