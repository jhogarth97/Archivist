using BaseLib.Abstracts;
using Archivist.ArchivistCode.Extensions;
using Godot;

namespace Archivist.ArchivistCode.Character;

public class ArchivistPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => Archivist.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}