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
    class PrescriptionService : IPrescriptionService
    {
        IPrescriptionDataAccess data;
        public PrescriptionService (IPrescriptionDataAccess data)
        {
            this.data = data;
        }

        public IEnumerable<LiveMedsEntity.Prescription> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.Prescription Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Prescription p)
        {
            return this.data.Insert(p);
        }

        public int Update(LiveMedsEntity.Prescription p)
        {
            return this.data.Update(p);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
