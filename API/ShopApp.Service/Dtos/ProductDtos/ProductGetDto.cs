namespace API.Service.Dtos.ProductDtos
{
    public class ProductGetDto
    {
        public string Name { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public ProductGetDtoBrandIn Brand { get; set; }


    }

    public class ProductGetDtoBrandIn
    {


        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
