using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface ICategoryDataAccess
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        int Insert(Category value);
        int Update(Category value);
        int Delete(int id);
    }
}
