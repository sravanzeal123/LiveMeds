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
    class UserService : IUserService
    {
        IUserDataAccess data;
        public UserService (IUserDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<LiveMedsEntity.User> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.User Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.User user)
        {
            return this.data.Insert(user);
        }

        public int Update(LiveMedsEntity.User user)
        {
            return this.data.Update(user);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
        public LiveMedsEntity.User GetByUserName(string userName)
        {

            return this.data.GetByUserName(userName);
        }
    }
}
