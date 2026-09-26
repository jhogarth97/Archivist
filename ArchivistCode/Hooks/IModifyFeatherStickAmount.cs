using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace Archivist.ArchivistCode.Hooks;

public interface IModifyFeatherStickAmount
{
    int ModifyFeatherStickAmount(Player player, int amount);
    
    Task AfterModifyFeatherStickAmount(
        PlayerChoiceContext ctx,
        Player player,
        int originalAmount,
        int modifiedAmount);
}