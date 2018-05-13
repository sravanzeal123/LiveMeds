using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class CategoryDataAccess : ICategoryDataAccess
    {
        LiveMedsDBContext context;
        public CategoryDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }
        public IEnumerable<LiveMedsEntity.Category> GetAll()
        {
            return this.context.Categories.ToList();
        }

        public LiveMedsEntity.Category Get(int id)
        {
            return this.context.Categories.SingleOrDefault(a => a.CategoryId == id);
        }

        public int Insert(LiveMedsEntity.Category value)
        {
            this.context.Categories.Add(value);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Category value)
        {
            LiveMedsEntity.Category ctg = this.context.Categories.SingleOrDefault(a => a.CategoryId == value.CategoryId);
            ctg.CategoryName = value.CategoryName;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Category ctg = this.context.Categories.SingleOrDefault(a => a.CategoryId ==id);
            this.context.Categories.Remove(ctg);
            return this.context.SaveChanges();
        }
    }
}
