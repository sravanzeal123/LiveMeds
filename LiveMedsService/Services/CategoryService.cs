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
    class CategoryService : ICategoryService
    {
        ICategoryDataAccess data;
        public CategoryService(ICategoryDataAccess data)
        {
            this.data = data;
          
        }
        public IEnumerable<LiveMedsEntity.Category> GetAll()
        {
            return this.data.GetAll();
        }

        public LiveMedsEntity.Category Get(int id)
        {
            return this.data.Get(id);
        }

        public int Insert(LiveMedsEntity.Category value)
        {
            return this.data.Insert(value);
        }

        public int Update(LiveMedsEntity.Category value)
        {
            return this.data.Update(value);
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }
    }
}
