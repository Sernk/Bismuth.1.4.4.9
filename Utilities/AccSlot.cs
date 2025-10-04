using Terraria;
using Terraria.Map;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class AccSlot : ModAccessorySlot
    {
        public override string Name => "SkillSlot";

        public override bool IsEnabled()
        {
            if (Player == null || !Player.active) return false;
            BismuthPlayer modPlayer = Player.GetModPlayer<BismuthPlayer>();
            return modPlayer != null && modPlayer.extraSlotUnlocked;
        }
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.accessory;
        }

        public override bool DrawDyeSlot => true;

        public override bool DrawFunctionalSlot => true;

        public override bool IsVisibleWhenNotEnabled() => false;
    }
}