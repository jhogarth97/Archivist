using Archivist.ArchivistCode.Commands;
using Archivist.ArchivistCode.Extensions;
using Archivist.ArchivistCode.Powers;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Archivist.ArchivistCode.Cards.Basic;

// Visual design note: Removing odd feathers from one's coat

public class Preen() : ArchivistCard(1, CardType.Attack,
    CardRarity.Basic, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(5, ValueProp.Move)];

    protected override HashSet<CardTag> CanonicalTags => [ArchivistExtensions.Feather];


    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);
        var feathers = cardPlay.Target.GetPowerAmount<FeatherPower>();
        for (var i = 0; i < feathers; i++)
        {
            await CommonActions.CardBlock(this, cardPlay);
            await FeatherCmd.RemoveFeather(CombatState, choiceContext, cardPlay.Target, 1);
        }
    }

    protected override void OnUpgrade() => DynamicVars.Block.UpgradeValueBy(3);

}