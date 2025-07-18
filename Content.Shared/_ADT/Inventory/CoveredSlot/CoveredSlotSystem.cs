using Content.Shared.Clothing.Components;
using Content.Shared.Inventory;
using Content.Shared.Inventory.Events;

namespace Content.Shared._ADT.Inventory.CoveredSlot;

/// <summary>
/// Handles prevention of items being unequipped and equipped from slots that are blocked by <see cref="CoveredSlotComponent"/>.
/// </summary>
public sealed class CoveredSlotSystem : EntitySystem
{
    [Dependency] private readonly InventorySystem _inventory = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<InventoryComponent, IsEquippingAttemptEvent>(OnEquipAttempt);
        SubscribeLocalEvent<InventoryComponent, IsUnequippingAttemptEvent>(OnUnequipAttempt);
    }

    private void OnEquipAttempt(Entity<InventoryComponent> ent, ref IsEquippingAttemptEvent args)
    {
        if (args.Cancelled)
            return;

        if (args.EquipTarget != ent.Owner)
            return;

        var blocker = GetBlocker(ent, args.SlotFlags);

        // Don't do anything if nothing is blocking the entity from equipping.
        if (blocker == null)
            return;

        args.Reason = Loc.GetString("covered-slot-component-blocked", ("item", blocker));
        args.Cancel();
    }

    private void OnUnequipAttempt(Entity<InventoryComponent> ent, ref IsUnequippingAttemptEvent args)
    {
        if (args.Cancelled)
            return;

        if (args.UnEquipTarget != ent.Owner)
            return;

        var blocker = GetBlocker(ent, args.SlotFlags);

        // Don't do anything if nothing is blocking the entity from unequipping.
        if (blocker == null)
            return;

        args.Reason = Loc.GetString("covered-slot-component-blocked", ("item", blocker));
        args.Cancel();
    }

    /// <summary>
    /// Used to get an entity that is blocking item from being equipped or unequipped.
    /// </summary>
    private EntityUid? GetBlocker(Entity<InventoryComponent> ent, SlotFlags slot)
    {
        foreach (var slotDef in ent.Comp.Slots)
        {
            if (!_inventory.TryGetSlotEntity(ent, slotDef.Name, out var entity))
                continue;

            if ((slotDef.SlotFlags & SlotFlags.POCKET) != 0)
                continue;

            if (!TryComp<CoveredSlotComponent>(entity, out var blockComponent) || (slot & blockComponent.Slots) == 0)
                continue;

            if (TryComp<MaskComponent>(entity, out var mask) && mask.IsToggled)
                continue;

            return entity;
        }

        return null;
    }
}
