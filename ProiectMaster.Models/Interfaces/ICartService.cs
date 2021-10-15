using ProiectMaster.Models.DTOs.VM;

namespace ProiectMaster.Models.Interfaces
{
    public interface ICartService
    {
        CartProductsVM GetCart(int id);
        void AddToCart(int id, int productId, int quantity);
        void RemoveFromCart(int id, int productId, int quantity);
    }
}
