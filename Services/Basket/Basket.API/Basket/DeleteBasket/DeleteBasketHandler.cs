namespace Basket.API.Basket;
public record DeleteBasketCommand(string UserName):ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);
public class DeleteBasketHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(request.UserName,cancellationToken);
        return new DeleteBasketResult(true);
    }
}
