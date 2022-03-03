using Eventuous;
using NodaTime;

namespace Billing.Payments;

public static class PaymentEvents
{
    [EventType("PaymentRecorded")]
    public record PaymentRecorded(
        string PaymentId,
        string OrderId,
        string Sku,
        LocalDate PlacedAt);
}