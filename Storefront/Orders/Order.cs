using Eventuous;
using static Storefront.Orders.OrderEvents;

namespace Storefront.Orders;

public record OrderId(string Value) : AggregateId(Value);

public class Order : Aggregate<OrderState, OrderId>
{
    public void Record(OrderId id, string sku, OrderDates orderDates, decimal price)
    {
        EnsureDoesntExist();

        var (placedAt, expectedDeliveryAt, deliverySpeed) = orderDates;

        Apply(new OrderRecorded(id, sku, price, placedAt, expectedDeliveryAt, deliverySpeed));
    }

    public void Import(OrderId id, string sku, OrderDates orderDates)
    {
        EnsureDoesntExist();

        var (placedAt, expectedDeliveryAt, _) = orderDates;

        Apply(new OrderImported(id, sku, placedAt, expectedDeliveryAt));
    }
    
    public void RecordPayment(string paymentId, decimal amount) {
        EnsureExists();

        if (State.HasPaymentRecord(paymentId)) return;

        var (previousState, currentState) =
            Apply(new OrderPaymentRegistered(State.Id, paymentId, amount));

        if (!previousState.IsFullyPaid() && currentState.IsFullyPaid())
            Apply(new OrderPaymentValidated(State.Id));
    }
}