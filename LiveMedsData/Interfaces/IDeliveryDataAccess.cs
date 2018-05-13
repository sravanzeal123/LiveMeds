using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IDeliveryDataAccess
    {
        IEnumerable<Delivery> GetAll();
        Delivery Get(int id);
        int Insert(Delivery value);
        int Update(Delivery value);
        int Delete(int id);
    }
}
