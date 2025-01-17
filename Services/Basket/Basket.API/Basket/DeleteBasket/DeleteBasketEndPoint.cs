namespace Basket.API.Basket;
public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result =await sender.Send(new DeleteBasketCommand(UserName: userName));
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        });
    }
}

