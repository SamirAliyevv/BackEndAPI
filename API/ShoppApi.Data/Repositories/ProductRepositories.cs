using ShopApp.core.Entities;
using ShopApp.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppApi.Data.Repositories
{
    public class ProductRepositories:Repository<Product>,IProductRepositories
    {
        
        public ProductRepositories(ShopDbContext context):base(context)
        {

        }   
        
    }
}
