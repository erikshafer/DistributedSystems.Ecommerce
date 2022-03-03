using NodaTime;

namespace Storefront.Orders;

public static class Commands
{
    public record RecordOrder(
        string OrderId,
        string Sku,
        decimal Price,
        LocalDate PlacedAt,
        LocalDate ExpectedDeliveryAt,
        DeliverySpeed DeliverySpeed);
    
    public record ImportOrder(
        string OrderId,
        string Sku,
        LocalDate PlacedAt,
        LocalDate ExpectedDeliveryAt,
        DeliverySpeed DeliverySpeed);
}