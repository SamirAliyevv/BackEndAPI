using API.DAL;
using Microsoft.AspNetCore.Http;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Dtos.ProductDtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ProductsController(  ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("all")]
        public ActionResult<List<ProductListitemdto>> GetAll()
        {

            var data = _context.Products.Select(x => new ProductListitemdto
            {
                Name = x.Name,
                Id = x.Id

            }).ToList();

            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Productgetitem> Get(int id)
        {

            var entity = _context.Products.Find(id);
            if (entity == null) return StatusCode(404);
            var data = new Productgetitem
            {
                Name = entity.Name,
                SalePrice = entity.SalePrice,
                CostPrice = entity.CostPrice,
            };

            return Ok(data);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create(ProductCreateDto createDto)
        {
            Product entity = new Product
            {
                Name = createDto.Name,    
                SalePrice = createDto.SalePrice,  
                CostPrice = createDto.CostPrice,

            };
               _context.Products.Add(entity);
              _context.SaveChanges();

             return StatusCode(201, new {id = entity.Id});
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id,ProductUpdatedto dto)
        {
            var entity = _context.Products.Find(id);

            if (entity == null) return StatusCode(404);

            entity.Name = dto.Name;
            entity.SalePrice = dto.SalePrice;   
            entity.CostPrice = dto.CostPrice;   
            
            _context.SaveChanges();


            return NoContent();

        }

    }
}
