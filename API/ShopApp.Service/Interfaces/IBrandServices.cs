using API.Service.Dtos.BrandDtos;
using ShopApp.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Interfaces
{
    public interface IBrandServices
    {

        CreatedResultDto Create(BrandCreatDto dto);
        void Update(int id, BrandEditDto dto); 
        BrandGetDto GetById(int id);

        List<BrandGetAllDto>GetAll();
        void Delete(int id);
    }
}
