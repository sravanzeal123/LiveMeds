using LiveMedsData;
using LiveMedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService.Services
{
    class AdminService : IAdminService
    {
        IAdminDataAccess data;
        public AdminService(IAdminDataAccess data)
        {
            this.data = data;
          
        }
        public IEnumerable<LiveMedsEntity.Admin> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.Admin Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Admin admin)
        {
            return this.data.Insert(admin);
        }

        public int Update(LiveMedsEntity.Admin admin)
        {
            return this.data.Update(admin);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
        public LiveMedsEntity.Admin GetByUserName(string username)
        {
            return this.data.GetByUserName(username);
        }
    }
}
