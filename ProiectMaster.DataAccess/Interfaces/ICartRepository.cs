using ProiectMaster.Models.Entites.Many;
using System.Collections.Generic;

namespace ProiectMaster.DataAccess.Interfaces
{
    public interface ICartRepository
    {
        IEnumerable<CartsProduct> GetCartsProducts(int cartId);
        void AddCartsProduct(CartsProduct cartsProduct);
        void EditCartsProduct(CartsProduct cartsProduct);
        void DeleteCartsProduct(CartsProduct cartsProduct);
    }
}
