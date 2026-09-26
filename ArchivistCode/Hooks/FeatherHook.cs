using BaseLib.Hooks;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Archivist.ArchivistCode.Hooks;

public static class FeatherHook {
    
    public static int ModifyFeatherStickAmount(
        Player player,
        int amount,
        out IEnumerable<IModifyFeatherStickAmount> modifiers)
    {
        return HookUtils.Modify(player.Creature.CombatState, amount, ((m, a) => m.ModifyFeatherStickAmount(player, a)), out modifiers);
    }
    
    public static Task AfterFeatherStuck(ICombatState combatState, PlayerChoiceContext choiceContext, int featherAmount)
    {
        return Task.CompletedTask;
        //return HookUtils.Dispatch<IAfterFeatherStuck>(combatState, );
    }
    
    public static Task AfterFeatherRemoved(ICombatState combatState, PlayerChoiceContext choiceContext, int featherAmount)
    {
        return HookUtils.Dispatch<IFeatherRemoved>(combatState, choiceContext, m => m.AfterFeatherRemoved(combatState, featherAmount));
    }

    public static Task AfterFeatherFailedToStick(ICombatState combatState)
    {
        return Task.CompletedTask;
    }
    

}