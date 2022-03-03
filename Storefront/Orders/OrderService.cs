using Eventuous;
using static Storefront.Orders.Commands;

namespace Storefront.Orders;

public class OrderService : ApplicationService<Order, OrderState, OrderId>
{
    public OrderService(IAggregateStore store) : base(store)
    {
        OnNew<RecordOrder>((agg, cmd) => 
            agg.Record(
                new OrderId(cmd.OrderId),
                cmd.Sku,
                new OrderDates(cmd.PlacedAt, cmd.ExpectedDeliveryAt, cmd.DeliverySpeed),
                cmd.Price));
        
        OnAny<ImportOrder>(
            cmd => new OrderId(cmd.OrderId),
            (agg, cmd) => 
                agg.Import(
                    new OrderId(cmd.OrderId), 
                    cmd.Sku, 
                    new OrderDates(cmd.PlacedAt, cmd.ExpectedDeliveryAt, cmd.DeliverySpeed)));
    }
}