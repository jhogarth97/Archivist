using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace Archivist.ArchivistCode.Cards.Basic;

// Visual design note: The Librarian is holding up a book, blocking a monsters claw

public class DefendArchivist() : ArchivistCard(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new BlockVar(6, ValueProp.Move)
    ];
    
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Defend];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play) => await CommonActions.CardBlock(this, play);

    protected override void OnUpgrade() => DynamicVars.Block.UpgradeValueBy(3);
}