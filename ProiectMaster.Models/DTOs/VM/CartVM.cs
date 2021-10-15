using System.Collections.Generic;

namespace ProiectMaster.Models.DTOs.VM
{
    public class CartVM
    {
        public CartVM()
        {
            ProductDTOs = new List<ProductDTO>();
        }

        public IEnumerable<ProductDTO> ProductDTOs { get; set; }
    }

    public class ProductDTO
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class CartProductsVM
    {
        public int Id { get; set; }
        public List<ProductQuantity> ProductIds { get; set; }
    }

    public class ProductQuantity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
