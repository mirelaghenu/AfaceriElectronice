using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.Entites.Many;
using System.Collections.Generic;
using System.Linq;

namespace ProiectMaster.DataAccess.Repository
{
    public class CartsRepository : ICartRepository
    {
        protected readonly MagazinVirtualContext _db;
        public CartsRepository(MagazinVirtualContext db)
        {
            _db = db;
        }

        public void AddCartsProduct(CartsProduct cartsProduct)
        {
            _db.Add(cartsProduct);
            _db.SaveChanges();
        }

        public void DeleteCartsProduct(CartsProduct cartsProduct)
        {
            var product = GetProductToProcess(cartsProduct);
            _db.Remove(product);
            _db.SaveChanges();
        }

        public void EditCartsProduct(CartsProduct cartsProduct)
        {
            var product = GetProductToProcess(cartsProduct);
            product.Quantity = cartsProduct.Quantity;

            _db.Update(product);
            _db.SaveChanges();
        }

        public IEnumerable<CartsProduct> GetCartsProducts(int cartId)
        {
            return _db.Set<CartsProduct>().AsEnumerable();
        }

        private CartsProduct GetProductToProcess(CartsProduct cartsProduct)
        {
            return GetCartsProducts(cartsProduct.CartId).Where(x => x.ProductId == cartsProduct.ProductId).First();
        }
    }
}
