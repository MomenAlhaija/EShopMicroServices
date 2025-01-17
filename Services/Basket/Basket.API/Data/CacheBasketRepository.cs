﻿using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data;

public class CacheBasketRepository(IBasketRepository repository,IDistributedCache cache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var cacheBasket=await cache.GetStringAsync(userName,cancellationToken);
        if (!string.IsNullOrEmpty(cacheBasket))
           return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket)!;
        
        var basket= await repository.GetBasket(userName, cancellationToken);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket));
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        await repository.StoreBasket(basket, cancellationToken);
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
        return basket;

    }
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(userName, cancellationToken);
        await cache.RemoveAsync(userName, cancellationToken);
        return true;
    }

}
