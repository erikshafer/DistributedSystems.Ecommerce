using Eventuous;

namespace SupplyChain.Inventories;

public static class InventoryEvents
{
    [EventType("InventoryReceived")]
    public record InventoryReceived(
        string InventoryId,
        string Sku,
        int Quantity);
}