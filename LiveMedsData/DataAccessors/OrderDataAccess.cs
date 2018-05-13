using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class OrderDataAccess : IOrderDataAccess
    {
        LiveMedsDBContext context;
        public OrderDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }

        public IEnumerable<LiveMedsEntity.Order> GetAll(string type)
        {
            if(type == "false")
            {
                return this.context.Orders.ToList().Where(o => o.Delivered == "false");
            }
            else
            {
                return this.context.Orders.ToList().Where(o => o.Delivered == "true");
            }
            
        }

        public LiveMedsEntity.Order Get(int id)
        {
            return this.context.Orders.Include("Products").SingleOrDefault(o => o.OrderId == id);

        }

        public int Insert(LiveMedsEntity.Order value)
        {
            this.context.Orders.Add(value);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Order value)
        {
            LiveMedsEntity.Order mn = this.context.Orders.SingleOrDefault(m => m.OrderId == value.OrderId );
            mn.Delivery = value.Delivery;
            mn.DeliveryId = value.DeliveryId;
            mn.OrderId = value.OrderId;
            mn.OrderTime = value.OrderTime;
            mn.Delivered = value.Delivered;
            mn.Products = value.Products;
            mn.Total = value.Total;
            mn.User = value.User;
            mn.UserId = value.UserId;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Order mn = this.context.Orders.SingleOrDefault(m => m.OrderId == id);
            this.context.Orders.Remove(mn);
            return this.context.SaveChanges();
        }
    }
}
