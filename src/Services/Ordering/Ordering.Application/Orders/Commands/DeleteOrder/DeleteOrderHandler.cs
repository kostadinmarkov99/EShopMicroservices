
namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken ct)
    {
        // Delete Order entity from command object
        // Save to Database
        // Return result

        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext
            .Orders
            .FindAsync([orderId], cancellationToken: ct);

        if(order is null)
        {
            throw new OrderNotFoundException(command.OrderId.ToString());
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(ct);

        return new DeleteOrderResult(true);
    }
}