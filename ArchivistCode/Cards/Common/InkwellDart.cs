using Archivist.ArchivistCode.Cards;
using Archivist.ArchivistCode.Commands;
using Archivist.ArchivistCode.Extensions;
using Archivist.ArchivistCode.Powers;
using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

// Visual design note: Thrown feathers with INK dripping off it.

namespace Archivist.ArchivistCode.Cards.Common;

public class InkwellDart(): ArchivistCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(3, ValueProp.Move), new PowerVar<FeatherPower>(1), new PowerVar<WeakPower>(1)];
    protected override HashSet<CardTag> CanonicalTags => [ArchivistExtensions.Feather];
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);
        await CommonActions.CardAttack(this, cardPlay).Execute(choiceContext);
        if (FeatherCmd.CanRemoveFeather(cardPlay.Target, DynamicVars.Power<FeatherPower>().IntValue))
        {
            await FeatherCmd.RemoveFeather(CombatState, choiceContext, cardPlay.Target, this);
            await CommonActions.Apply<WeakPower>(choiceContext, this, cardPlay);
        }
    }

    protected override void OnUpgrade() => DynamicVars.Damage.UpgradeValueBy(3);
}