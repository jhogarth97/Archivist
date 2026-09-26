using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace Archivist.ArchivistCode.Hooks;

public interface IFeatherRemoved
{
    Task AfterFeatherRemoved(ICombatState combatState, int amount);
}