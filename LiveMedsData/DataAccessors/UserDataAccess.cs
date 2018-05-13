using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class UserDataAccess : IUserDataAccess
    {
        LiveMedsDBContext context;
        public UserDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }

        public IEnumerable<LiveMedsEntity.User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public LiveMedsEntity.User Get(int id)
        {
            return this.context.Users.SingleOrDefault(o => o.UserId == id);
        }

        public int Insert(LiveMedsEntity.User value)
        {
            this.context.Users.Add(value);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.User value)
        {
            LiveMedsEntity.User mn = this.context.Users.SingleOrDefault(m => m.UserId == value.UserId);
            mn.Email = value.Email;
            mn.Name = value.Name;
            mn.Orders = value.Orders;
            mn.Password = value.Password;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.User mn = this.context.Users.SingleOrDefault(m => m.UserId == id);
            this.context.Users.Remove(mn);
            return this.context.SaveChanges();
        }
        public LiveMedsEntity.User GetByUserName(string userName)
        {
            return this.context.Users.SingleOrDefault(o => o.UserName == userName);
        }
    }
}
