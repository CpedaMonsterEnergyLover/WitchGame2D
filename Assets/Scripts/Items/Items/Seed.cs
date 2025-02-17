
public class Seed : Item, IUsable
{
    public new SeedData Data => (SeedData) data;
    
    public void Use(ItemSlot slot, Entity entity = null, WorldTile tile = null, Interactable interactable = null)
    {
        if(tile is null) return;
        tile.SetInteractable(new HerbSaveData()
            {
                initialized = true,
                id = Data.herb.id,
                creationTime = Timeline.TotalMinutes
            });
        slot.RemoveItem(1);
    }

    public bool AllowUse(Entity entity = null, WorldTile tile = null, Interactable interactable = null)
    {
        return interactable is CropBed;
    }
    
    public Seed(ItemIdentifier identifier) : base(identifier)
    {
    }
}
