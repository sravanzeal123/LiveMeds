using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData
{
    public interface IAdminDataAccess
    {
        IEnumerable<Admin> GetAll();
        Admin Get(int id);
        int Insert(Admin admin);
        int Update(Admin admin);
        int Delete(int id);
        Admin GetByUserName(string username);
    }
}
