using Eventuous;
using static Billing.Payments.PaymentEvents;

namespace Billing.Payments;

public record PaymentState : AggregateState<PaymentState, PaymentId>
{
    public PaymentState()
    {
        On<PaymentRecorded>((state, recorded) =>
            state with { Id = new PaymentId(recorded.PaymentId) });

        On<PaymentCancelled>((state, cancelled) =>
            state with { Id = new PaymentId(cancelled.PaymentId) });

        // TODO
    }

    private PaymentSource SourceOfPayment { get; init; } = PaymentSource.Unset;
    
    private decimal Price { get; init; }
    
    private decimal AmountPaid { get; init; }
    
    public bool IsFullyPaid() => AmountPaid >= Price;

    public bool IsOverpaid() => AmountPaid > Price;

    private enum PaymentSource
    {
        Unset = 0,
        Unknown,
        PalPay,
        NilePay,
        Cash,
        Check
    }
}