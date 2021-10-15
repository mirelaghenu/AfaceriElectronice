using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites.Many;
using ProiectMaster.Models.Interfaces;
using System.Linq;

namespace ProiectMaster.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository repository;

        public CartService(ICartRepository repository)
        {
            this.repository = repository;
        }

        public void AddToCart(int userId, int productId, int quantity)
        {
            var cartsProduct = new CartsProduct
            {
                CartId = userId,
                ProductId = productId,
                Quantity = quantity
            };

            repository.AddCartsProduct(cartsProduct);
        }

        public void RemoveFromCart(int userId, int productId, int quantity)
        {
            var cartsProduct = new CartsProduct { CartId = userId, ProductId = productId };
            var cartsProducts = repository.GetCartsProducts(userId).Where(x => x.ProductId == productId).First();
            if (cartsProducts.Quantity <= quantity)
            {
                repository.DeleteCartsProduct(cartsProduct);
            }
            else
            {
                repository.EditCartsProduct(cartsProduct);
            }
        }

        public CartProductsVM GetCart(int userId)
        {
            var cartsProducts = repository.GetCartsProducts(userId);
            if (!cartsProducts.Any())
                return null;

            return new CartProductsVM
            {
                Id = cartsProducts.First().CartId,
                ProductIds = cartsProducts.Select(x => new ProductQuantity
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                }).ToList()
            };
        }
    }
}
