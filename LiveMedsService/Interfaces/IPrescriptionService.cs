using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService.Interfaces
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetAll();
        Prescription Get(int id);
        int Insert(Prescription p);
        int Update(Prescription p);
        int Delete(int id);
    }
}
