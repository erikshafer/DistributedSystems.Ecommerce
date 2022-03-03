using Eventuous;
using NodaTime;

namespace Storefront.Orders;

public static class OrderEvents
{
    [EventType("OrderRecorded")]
    public record OrderRecorded(
        string OrderId,
        string Sku,
        decimal Price,
        LocalDate PlacedAt,
        LocalDate ExpectedDeliveryAt,
        DeliverySpeed DeliverySpeed);

    public record OrderPaymentRegistered(
        string OrderId,
        string PaymentId,
        decimal AmountPaid);

    [EventType("OrderPaymentValidated")]
    public record OrderPaymentValidated(string OrderId);

    [EventType("OrderCancelled")]
    public record OrderCancelled(string OrderId);

    [EventType("OrderImported")]
    public record OrderImported(
        string OrderId,
        string Sku,
        LocalDate PlacedAt,
        LocalDate ExpectedDeliveryAt);
}

public enum DeliverySpeed
{
    Unset = 0,
    Unknown,
    SameDay,
    NextDay,
    TwoDay,
    Other
}