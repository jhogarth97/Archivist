using Archivist.ArchivistCode.Commands;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Archivist.ArchivistCode.Cards.Basic;

// Visual design note: Writing with a quill on a bit of paper and its on fire.
// Think the Death Note scene where Light is writing a ton of names down.

public class QuillScribe() : ArchivistCard(1, CardType.Attack,
    CardRarity.Basic, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CommonActions.CardAttack(this, play).Execute(choiceContext);

        await FeatherCmd.ApplyFeather(CombatState, choiceContext, play.Target, this); 
    }
    
    protected override void OnUpgrade() => DynamicVars.Damage.UpgradeValueBy(3);

}