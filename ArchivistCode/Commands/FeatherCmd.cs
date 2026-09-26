using Archivist.ArchivistCode.Hooks;
using Archivist.ArchivistCode.Powers;
using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace Archivist.ArchivistCode.Commands;

public static class FeatherCmd
{
    /// <summary>
    /// Applies Feather logic in one place.
    /// Checks if Feather can be applied, and if so, applies it via the CommonActions Apply.
    /// </summary>
    /// <param name="combatState"></param>
    /// <param name="choiceContext">As this is a combat action, there must be a choice context</param>
    /// <param name="target">The target creature</param>
    /// <param name="card">The card this is applied from. Must have a FeatherPower dynamicvar otherwise error thrown.</param>
    public static async Task ApplyFeather(ICombatState? combatState, PlayerChoiceContext choiceContext, Creature? target, CardModel card)
    {
        if (combatState == null || target == null) return;
        if (CanApplyFeather(target, card))
        {
            await FeatherHook.AfterFeatherFailedToStick(combatState);
            return;
        }
        await CommonActions.Apply<FeatherPower>(choiceContext, target, card);
        await FeatherHook.AfterFeatherStuck(combatState, choiceContext, card.DynamicVars.Power<FeatherPower>().IntValue);
    }
    
    public static async Task<int> RemoveFeather(ICombatState? combatState, PlayerChoiceContext choiceContext, Creature target, int amount, bool fakeRemoval = false)
    {
        ArgumentNullException.ThrowIfNull(combatState);

        // We can't remove/fake remove feathers if there were NONE to begin with.
        var currentFeathers =  target.GetPowerAmount<FeatherPower>();
        if (currentFeathers == 0) return 0 ;
        if (currentFeathers < amount)
        {
            amount = Math.Min(amount, currentFeathers - amount);
        }
        
        if (fakeRemoval)
        {
            await FeatherHook.AfterFeatherRemoved(combatState, choiceContext, amount);
            return amount;
        }

        await PowerCmd.ModifyAmount(choiceContext, target.GetPower<FeatherPower>()!, -amount, null, null);
        await FeatherHook.AfterFeatherRemoved(combatState, choiceContext, amount);
        return amount;

    }
    
    public static async Task<int> RemoveFeather(ICombatState? combatState, PlayerChoiceContext choiceContext, Creature target, CardModel card, bool fakeRemoval = false)
    {
        return await RemoveFeather(combatState, choiceContext, target, card.DynamicVars.Power<FeatherPower>().IntValue, fakeRemoval);
    }

    public static async Task<int> RemoveAllFeathers(ICombatState? combatState, PlayerChoiceContext choiceContext,
        Creature target, bool fakeRemoval = false)
    {
        if (combatState == null) return 0;
        var feathers = target.GetPowerAmount<FeatherPower>();
        if (feathers == 0) return 0;
        
        return await RemoveFeather(combatState, choiceContext, target, feathers, fakeRemoval);
    }

    public static bool CanRemoveFeather(Creature target, int amount)
    {
        return target.GetPowerAmount<FeatherPower>() >= amount;
    }

    private static bool CanApplyFeather(Creature target, CardModel card)
    {
        return target.GetPowerAmount<FeatherPower>() + card.DynamicVars.Power<FeatherPower>().BaseValue > 3;
    }
}