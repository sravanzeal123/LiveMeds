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
    class ManufacturerService: IManufacturerService
    {
        IManufacturerDataAccess data;
        public ManufacturerService ( IManufacturerDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<LiveMedsEntity.Manufacturer> GetAll()
        {
            return this.data.GetAll();

        }

        public LiveMedsEntity.Manufacturer Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Manufacturer m)
        {
            return this.data.Insert(m);
        }

        public int Update(LiveMedsEntity.Manufacturer m)
        {
            return this.data.Update(m);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
