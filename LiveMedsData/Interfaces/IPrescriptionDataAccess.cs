using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IPrescriptionDataAccess
    {
        IEnumerable<Prescription> GetAll();
        Prescription Get(int id);
        int Insert(Prescription value);
        int Update(Prescription value);
        int Delete(int id);
    }
}
