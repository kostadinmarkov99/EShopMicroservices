using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data;

public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

        if (!string.IsNullOrEmpty(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
        }

        var basket = await repository.GetBasketAsync(userName, cancellationToken);

        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);

        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken ct = default)
    {
        await repository.StoreBasket(basket, ct);

        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), ct);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken ct = default)
    {
        await repository.DeleteBasket(userName, ct);

        await cache.RemoveAsync(userName, ct);

        return true;
    }
}