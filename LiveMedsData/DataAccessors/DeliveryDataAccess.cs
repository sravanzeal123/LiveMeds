using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class DeliveryDataAccess : IDeliveryDataAccess
    {
        LiveMedsDBContext context;
        public DeliveryDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<LiveMedsEntity.Delivery> GetAll()
        {
            return this.context.Deliveries.ToList();
            
        }

        public LiveMedsEntity.Delivery Get(int id)
        {
           return this.context.Deliveries.SingleOrDefault(d => d.DeliveryId == id);

        }

        public int Insert(LiveMedsEntity.Delivery value)
        {
            this.context.Deliveries.Add(value);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Delivery value)
        {
            LiveMedsEntity.Delivery dlv = this.context.Deliveries.SingleOrDefault(d => d.DeliveryId == value.DeliveryId);
            dlv.DeliveryTime = value.DeliveryTime;
            dlv.Orders = value.Orders;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Delivery dlv = this.context.Deliveries.SingleOrDefault(d => d.DeliveryId == id);
            this.context.Deliveries.Remove(dlv);
            return this.context.SaveChanges();
        }
    }
}
