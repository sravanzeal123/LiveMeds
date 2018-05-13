using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class AdminDataAccess : IAdminDataAccess
    {
        LiveMedsDBContext context;
        public AdminDataAccess ( LiveMedsDBContext context)
        {
            this.context = context;
          
        }
        public IEnumerable<LiveMedsEntity.Admin> GetAll()
        {
            return this.context.Admins.ToList();
        }

        public LiveMedsEntity.Admin Get(int id)
        {
            return this.context.Admins.SingleOrDefault(a => a.AdminId == id);
        }

        public int Insert(LiveMedsEntity.Admin admin)
        {
            this.context.Admins.Add(admin);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Admin admin)
        {
            LiveMedsEntity.Admin ad = this.context.Admins.SingleOrDefault(a => a.AdminId == admin.AdminId);
            ad.AdminName = admin.AdminName;
            ad.AdminUserName = admin.AdminUserName;
            ad.AdminEmail = admin.AdminEmail;
            ad.AdminPassword = admin.AdminPassword;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Admin ad = this.context.Admins.SingleOrDefault(a => a.AdminId == id);
            this.context.Admins.Remove(ad);
            return this.context.SaveChanges();
        }
        public LiveMedsEntity.Admin GetByUserName(string username)
        {
            return this.context.Admins.SingleOrDefault(a => a.AdminUserName == username);
        }
    }
}
