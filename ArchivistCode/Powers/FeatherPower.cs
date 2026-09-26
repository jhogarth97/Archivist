using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;

namespace Archivist.ArchivistCode.Powers;

public class FeatherPower : ArchivistPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;
    
    public override Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        // DO HOOK STUFF HERE!
        return base.AfterApplied(applier, cardSource);
    }
}