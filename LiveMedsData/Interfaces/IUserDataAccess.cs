using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IUserDataAccess
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        int Insert(User value);
        int Update(User value);
        int Delete(int id);
        User GetByUserName(string userName);
    }
}
