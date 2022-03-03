using NodaTime;

namespace Storefront.Orders;

public record OrderDates
{
    public LocalDate PlacedAt  { get; }
    public LocalDate ExpectedDeliveryAt { get; }
    public DeliverySpeed DeliverySpeed { get; }
    
    public OrderDates(
        LocalDate placedAt,
        LocalDate expectedDeliveryAt,
        DeliverySpeed deliverySpeed)
    {
        if (placedAt >= expectedDeliveryAt)
            throw new ArgumentOutOfRangeException(
                nameof(expectedDeliveryAt),
                "Placed at should be after expected");

        if (deliverySpeed is DeliverySpeed.Unset)
            throw new ArgumentOutOfRangeException(
                nameof(deliverySpeed),
                "Delivery speed not set");

        PlacedAt = placedAt;
        ExpectedDeliveryAt = expectedDeliveryAt;
        DeliverySpeed = deliverySpeed;
    }

    public void Deconstruct(
        out LocalDate placedAt,
        out LocalDate expectedDeliveryAt,
        out DeliverySpeed deliverySpeed)
    {
        placedAt = PlacedAt;
        expectedDeliveryAt = ExpectedDeliveryAt;
        deliverySpeed = DeliverySpeed;
    }
}