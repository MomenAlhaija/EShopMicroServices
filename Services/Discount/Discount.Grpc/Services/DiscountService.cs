using Discount.Grpc.Models;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountDataContext dbContext,ILogger<DiscountService> logger):DiscountProtoService.DiscountProtoServiceBase
{
    
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
       var coupon=await dbContext.coupons.FirstOrDefaultAsync(coupon=>coupon.ProductName== request.ProductName);
       if(coupon==null)
            return new CouponModel { ProductName = request.ProductName, Amount = 0, Description = "No Discount On Product" };
       else 
            return coupon.Adapt<CouponModel>();
    }
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon=request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalied Request Object."));

        dbContext.coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount Is Successfully Created On Product :{ProductName}", coupon.ProductName);

        return coupon.Adapt<CouponModel>();
    }
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, request.Coupon.ProductName));

        dbContext.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount Is Successfully Updated On Product :{ProductName}", coupon.ProductName);

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<DeleteCouponResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.coupons.FirstOrDefaultAsync(coupon => coupon.ProductName == request.ProductName);
        if(coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, request.ProductName));

        dbContext.coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount Is Successfully Removed On Product :{ProductName}", request.ProductName);

        return new DeleteCouponResponse { Success=true};


    }
}
