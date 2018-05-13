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
    class DeliveryService : IDeliveryService
    {
        IDeliveryDataAccess data;
        public DeliveryService(IDeliveryDataAccess data)
        {
            this.data = data;
          
        }
        public IEnumerable<LiveMedsEntity.Delivery> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.Delivery Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Delivery value)
        {
            return this.data.Insert(value);
        }

        public int Update(LiveMedsEntity.Delivery value)
        {
            return this.data.Update(value);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
