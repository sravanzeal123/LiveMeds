using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService.Interfaces
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetAll();
        Manufacturer Get(int id);
        int Insert(Manufacturer m);
        int Update(Manufacturer m);
        int Delete(int id);
    }
}
