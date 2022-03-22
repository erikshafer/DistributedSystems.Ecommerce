using Eventuous;

namespace SupplyChain.Inventories;

public record InventoryId(string Value) : AggregateId(Value);

public class Inventory : Aggregate<InventoryState, InventoryId>
{
    public void Received(InventoryId id, string sku, int quantity)
    {
        EnsureDoesntExist();

        Apply(new InventoryEvents.InventoryReceived(id, sku, quantity));
    }
}