using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        int Insert(Product value);
        int Update(Product value);
        int Delete(int id);
    }
}
