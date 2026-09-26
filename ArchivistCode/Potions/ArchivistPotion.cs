using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Archivist.ArchivistCode.Character;
using Archivist.ArchivistCode.Extensions;

namespace Archivist.ArchivistCode.Potions;

[Pool(typeof(ArchivistPotionPool))]
public abstract class ArchivistPotion : CustomPotionModel
{
    public override string? CustomPackedImagePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionImagePath();

    public override string? CustomPackedOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionOutlineImagePath();
}