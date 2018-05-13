using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IManufacturerDataAccess
    {
        IEnumerable<Manufacturer> GetAll();
        Manufacturer Get(int id);
        int Insert(Manufacturer value);
        int Update(Manufacturer value);
        int Delete(int id);
    }
}
