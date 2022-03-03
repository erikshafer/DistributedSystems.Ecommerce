using System.Collections.Immutable;
using Eventuous;

namespace Storefront.Orders;

public record OrderState : AggregateState<OrderState, OrderId>
{
    public OrderState()
    {
        On<OrderEvents.OrderRecorded>((state, recorded) =>
            state with { Id = new OrderId(recorded.OrderId), Price = recorded.Price });

        On<OrderEvents.OrderImported>((state, imported) =>
            state with { Id = new OrderId(imported.OrderId) });

        On<OrderEvents.OrderPaymentRegistered>((state, paid) =>
            state with
            {
                PaymentRecords = state.PaymentRecords.Add(new PaymentRecord(paid.PaymentId, paid.AmountPaid)),
                AmountPaid = state.AmountPaid + paid.AmountPaid
            });
    }

    private decimal Price { get; init; }
    
    private decimal AmountPaid { get; init; }
    
    private ImmutableList<PaymentRecord> PaymentRecords { get; init; } = ImmutableList<PaymentRecord>.Empty;

    public bool HasPaymentRecord(string paymentId) => PaymentRecords.Any(x => x.PaymentId == paymentId);
    
    public bool IsFullyPaid() => AmountPaid >= Price;

    public bool IsOverpaid() => AmountPaid > Price;
    
    record PaymentRecord(string PaymentId, decimal Amount);
}