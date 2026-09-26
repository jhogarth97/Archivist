using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Rooms;

namespace Archivist.ArchivistCode.Enchantments;

public abstract class ArchivistEnchantment: CustomEnchantmentModel
{
    public override Task AfterCombatEnd(CombatRoom room)
    {
        CardCmd.ClearEnchantment(Card);
        return base.AfterCombatEnd(room);
    }
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card != Card) return;
        
        // IMPLIES ONLY 1 enchantment possible per card. Maybe I keep this, maybe I override that functionality. 
        // Or I roll my own *shudder* enchantment system that exists alongside the existing one...
        CardCmd.ClearEnchantment(Card);
        await base.AfterCardPlayed(choiceContext, cardPlay);
    }
}