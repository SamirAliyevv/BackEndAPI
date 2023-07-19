using API.Service.Dtos.ProductDtos;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ShopApp.core.Entities;
    using ShopApp.core.Repositories;
    using ShoppApi.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepositories _productRepositories;

        private readonly IBrandRepositories _brandRepositories;
        public ProductsController(IProductRepositories productRepositories, IBrandRepositories brandRepositories)
        {
            _productRepositories = productRepositories;
            _brandRepositories = brandRepositories;
        }


        [HttpPost]
        [Route("")]
        public IActionResult Create(ProductCreatDto dto)
        {
            if (!_brandRepositories.IsExists(x => x.Id == dto.BrandId))
            {
                ModelState.AddModelError("BrandId", $"Brand not found by Id {dto.BrandId}");
                return BadRequest(ModelState);
            }

            Product product = new Product

            {
                BrandId = dto.BrandId,
                Name = dto.Name,
                SalePrice = dto.SalePrice,
                CostPrice = dto.CostPrice,
                CreadAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4)
            };
            _productRepositories.Add(product);
            _productRepositories.Commit();
            return StatusCode(200, new { Id = product.Id });

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {

            Product product = _productRepositories.Get(x => x.Id == id, "Brand");

            if (product == null) return NotFound();


            ProductGetDto productGetDto = new ProductGetDto
            {
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,
                Brand = new ProductGetDtoBrandIn
                {
                    Id = product.BrandId,
                    Name = product.Brand.Name

                }

            };

            return Ok(productGetDto);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(int id, ProductEditDto dto)
        {
            Product product = _productRepositories.Get(x => x.Id == id);

            if (product == null) return NotFound();

            if (product.Name != dto.Name && _productRepositories.IsExists(x => x.Name == dto.Name))
            {
                ModelState.AddModelError("Name", "Name is already token");
                return BadRequest(ModelState);


            }
            product.Name = dto.Name;
            _productRepositories.Commit();
            return NoContent();

        }



        [HttpDelete]
        [Route("{id}")]

        public IActionResult Delete(int id)
        {
            Product product = _productRepositories.Get(x => x.Id == id);

            if (product == null) return NotFound();

            _productRepositories.Delete(product);
            _productRepositories.Commit();
            return NoContent();


        }


    }

}
