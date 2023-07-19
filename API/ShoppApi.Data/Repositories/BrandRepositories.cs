using ShopApp.core.Entities;
using ShopApp.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppApi.Data.Repositories
{
    public class BrandRepositories :Repository<Brand>, IBrandRepositories
    {
        public BrandRepositories(ShopDbContext context):base(context) 
        {
        }

      

        
    }
}
