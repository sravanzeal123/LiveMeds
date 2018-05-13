using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IOrderDataAccess
    {
        IEnumerable<Order> GetAll(string type);
        Order Get(int id);
        int Insert(Order value);
        int Update(Order value);
        int Delete(int id);
    }
}
