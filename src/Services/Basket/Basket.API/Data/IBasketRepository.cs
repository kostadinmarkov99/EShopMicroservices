namespace Basket.API.Data;
 
public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default!);

    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken ct = default!);

    Task<bool> DeleteBasket(string userName, CancellationToken ct = default!);
}