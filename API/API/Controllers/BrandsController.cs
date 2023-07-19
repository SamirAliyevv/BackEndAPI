
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.core.Entities;
using ShopApp.core.Repositories;
using ShoppApi.Data;
using API.Service.Dtos.BrandDtos;
using ShopApp.Service.Interfaces;
using ShopApp.Service.Exceptions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {      
        private readonly IBrandRepositories _brandRepositories;
        private readonly IProductRepositories _productRepositories;
        private readonly IBrandServices _brandServices;

        public BrandsController( IBrandRepositories brandRepositories,IProductRepositories productRepositories,IBrandServices brandServices)
        {
            _brandRepositories = brandRepositories;
            _productRepositories = productRepositories;
            _brandServices = brandServices;
        }







        [HttpGet]
        [Route("all")]

        public ActionResult<List<BrandGetAllDto>> GetAll()
        {

            var brandDtos = _brandRepositories.GetQueryable(x=>x.Products.Count>0).Select(x => new BrandGetAllDto { Id = x.Id, Name = x.Name }).ToList();
            return Ok(brandDtos);

        }







        [HttpGet]
        [Route("{id}")]
              
        public ActionResult< BrandGetDto> Get(int id)
        {


            try
            {
                return Ok(_brandServices.GetById(id));

            }
            catch (NotFoundException e)
            {
                 

                return NotFound();
            }


            
        }





        [HttpPost]
        [Route("")]


        public IActionResult Create(BrandCreatDto dto)
        {

            try
            {
                var result = _brandServices.Create(dto);

                return StatusCode(201, result);

            }
            catch (EntityDublicateException e)
            {

                 ModelState.AddModelError("Name", e.Message);
                return BadRequest(ModelState);
            }
      

        }


        [HttpPut]
        [Route("{id}")] 
        public IActionResult Edit( int id,BrandEditDto dto)
        {
            try
            {
                _brandServices.Update(id, dto);
            }
            catch (NotFoundException e)
            {
                 
                 return NotFound();
                
            }
            catch (EntityDublicateException e)
            {
                ModelState.AddModelError("Name",e.Message);

                return BadRequest();    
            }

            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete(int id) 
        {
            try
            {
                _brandServices.Delete(id);


            }
            catch (NotFoundException e  )
            {

              return NotFound();
            }

            return NoContent() ;

        }

            
        
    }
}
