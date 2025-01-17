namespace Basket.API.Basket;
public record StoreBasketRequest(ShoppingCart ShoppingCart);
public record StoreBasketResponse(string UserName);
public class StoreBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket",async(StoreBasketRequest request,ISender sender)=>{

            var storeBasket = request.Adapt<StoreBasketCommand>();
            var result = await sender.Send(storeBasket);
            var response=result.Adapt<StoreBasketResponse>();
            return Results.Created($"/basket/{response.UserName}", response);
        });
    }
}
