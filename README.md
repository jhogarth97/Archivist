# Archivist

## Archetypes

Archetypes define the themes of the character and control how you might build a character.

### Feathers

Feathers are a mechanic in which certain attacks apply `Feather` to an enemy as a debuff power
that can stack up to 3 (can be extended through Player powers).
Certain card effects under this Feathers archetype rely on the enemy an amount of Feathers applied to them to trigger
additional effects.

Triggers:
- `OnFeatherApplied` : Triggers when an enemy has the Feather debuff applied to them successfully. This means that 
the enemy has below the cap of Feathers before new Feathers are added to them. 
If an enemy has 2 feathers, and you try to apply 2 feathers (cap 3), only 1 feather will be applied but this will be considered successful.
- `OnFeatherRemoved` : Triggers when a Feather is removed from an enemy. Requires the enemy has the Feather debuff applied.
If the enemy has no Feathers, this affect will not trigger.
- `OnFeatherAppliedFailed` : Triggers when a Feather cannot be applied to the enemy. This may be due to the enemy being at
the feather cap.

### Reverie

A stacking counter (called Waking) on the Archivist that grants effects at various levels of stacking. It naturally stacks to offset
its strength, the cap acts as a timer in which hitting it will grant a negative effect on the Archivist and remove 
their bonuses until brought below the cap.

- `OnWakingGained` : Triggered when you gain Waking. This allows relics/powers to proc, as well as Waking's own self buffs.
- `OnWakingRemoved` : Triggered when remove Waking. This allows relics/powers to proc, as well as Waking's own self buffs.
- `OnWakingModified` : Triggered when the Waking counter is actually modified. While the other triggers may change with
0 value modification, this only triggers if the value actually changes by 1 in either direction.

### Enchantments

This already exists in the game but this character extends the functionality. Firstly, the Archivist gets additional
exclusive enchantments. Secondly, they can apply multiple enchantments to their cards that other characters cannot.

**THIS REQUIRES PATCHING AND WILL SUCK!**

And also a LOT of balancing! As a result, this is the last thing I will properly implement since I'm less clear on how
it will work.