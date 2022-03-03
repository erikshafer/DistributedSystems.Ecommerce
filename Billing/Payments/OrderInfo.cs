using NodaTime;

namespace Billing.Payments;

public record OrderInfo
{
    public string Id { get; }
    public string Sku { get; }
    public LocalDate PlacedAt { get; }

    public OrderInfo(string id, string sku, LocalDate placedAt)
    {
        Id = id;
        Sku = sku;
        PlacedAt = placedAt;
    }

    public void Deconstruct(out string id, out string sku, out LocalDate placedAt)
    {
        id = Id;
        sku = Sku;
        placedAt = PlacedAt;
    }
}