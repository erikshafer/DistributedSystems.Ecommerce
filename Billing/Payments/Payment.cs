using Eventuous;

namespace Billing.Payments;

public record PaymentId(string Value) : AggregateId(Value);

public class Payment : Aggregate<PaymentState, PaymentId>
{
    public void Record(PaymentId id, OrderInfo orderInfo)
    {
        EnsureDoesntExist();

        Apply(new PaymentEvents.PaymentRecorded(id, orderInfo.Id, orderInfo.Sku, orderInfo.PlacedAt));
    }
}