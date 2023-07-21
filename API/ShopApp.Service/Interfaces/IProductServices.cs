using API.Service.Dtos.BrandDtos;
using API.Service.Dtos.ProductDtos;
using ShopApp.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Interfaces
{
    public  interface IProductServices
    {
        CreatedResultDto Create(ProductCreatDto dto);
        void Update(int id, ProductEditDto dto);
        ProductGetDto GetById(int id);

     
        void Delete(int id);

    }
}
