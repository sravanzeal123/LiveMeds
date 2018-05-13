using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class PrescriptionDataAccess : IPrescriptionDataAccess
    {
        LiveMedsDBContext context;
        public PrescriptionDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }


        public IEnumerable<LiveMedsEntity.Prescription> GetAll()
        {
            return this.context.Prescriptions.ToList();
        }

        public LiveMedsEntity.Prescription Get(int id)
        {
            return this.context.Prescriptions.Include("Products").SingleOrDefault(o => o.PrescriptionId == id);
        }

        public int Insert(LiveMedsEntity.Prescription prescription)
        {
            this.context.Prescriptions.Add(prescription);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Prescription prescription)
        {
            LiveMedsEntity.Prescription mn = this.context.Prescriptions.SingleOrDefault(m => m.PrescriptionId == prescription.PrescriptionId);
            mn.PrescriptionCategoryName = prescription.PrescriptionCategoryName;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Prescription mn = this.context.Prescriptions.SingleOrDefault(m => m.PrescriptionId == id);
            this.context.Prescriptions.Remove(mn);
            return this.context.SaveChanges();
        }
    }
}
