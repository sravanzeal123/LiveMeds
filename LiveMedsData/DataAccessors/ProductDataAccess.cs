using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.DataAccessors
{
    class ProductDataAccess : IProductDataAccess
    {
        LiveMedsDBContext context;
        public ProductDataAccess(LiveMedsDBContext context)
        {
            this.context = context;
          
        }
        public IEnumerable<LiveMedsEntity.Product> GetAll()
        {

            return this.context.Products.Include("Category").Include("Manufacturer").ToList();
        }

      

        public LiveMedsEntity.Product Get(int id)
        {
            return this.context.Products.Include("Category").SingleOrDefault(p => p.ProductId == id);
        }

        public int Insert(LiveMedsEntity.Product product)
        {
            this.context.Products.Add(product);
            return this.context.SaveChanges();
        }

        public int Update(LiveMedsEntity.Product product)
        {
            LiveMedsEntity.Product ad = this.context.Products.SingleOrDefault(a => a.ProductId == product.ProductId);
            
            ad.CategoryId = product.CategoryId;
            ad.ManufacturerId = product.ManufacturerId;
            ad.ProductBuyingPrice = product.ProductBuyingPrice;
            ad.ProductDescription = product.ProductDescription;
            ad.ProductFormulation = product.ProductFormulation;
            if (product.ProductImagePath != null)ad.ProductImagePath = product.ProductImagePath;
            ad.ProductName = product.ProductName;
            ad.ProductPackagingType = product.ProductPackagingType;
            ad.ProductQuantity = product.ProductQuantity;
            ad.ProductSellingPrice = product.ProductSellingPrice;
            ad.ProductSold = product.ProductSold;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            LiveMedsEntity.Product ad = this.context.Products.SingleOrDefault(a => a.ProductId == id);
            this.context.Products.Remove(ad);
            return this.context.SaveChanges();
        }
    }
}
