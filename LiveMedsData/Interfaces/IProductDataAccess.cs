﻿using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData.Interfaces
{
    public interface IProductDataAccess
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        int Insert(Product product);
        int Update(Product product);
        int Delete(int id);
    }
}
