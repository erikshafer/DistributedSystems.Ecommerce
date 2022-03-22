using System.Collections.Immutable;
using Eventuous;

namespace SupplyChain.Inventories;

public record InventoryState : AggregateState<InventoryState, InventoryId>
{
    public InventoryState()
    {
        On<InventoryEvents.InventoryReceived>((state, received) =>
            state with
            {
                Id = new InventoryId(received.InventoryId),
                Sku = received.Sku ,
                QuantityOnHand = received.Quantity
            });
        
        // TODO
    }
    
    private string Sku { get; init; } = string.Empty;
    private int QuantityOnHand { get; init; }

    private ImmutableList<InventoryRecord> InventoryRecords { get; init; } = ImmutableList<InventoryRecord>.Empty;


    record InventoryRecord(string InventoryId, int Quantity);
}