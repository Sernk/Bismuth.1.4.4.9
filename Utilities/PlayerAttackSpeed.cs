using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class PlayerAttackSpeed : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            Player player = Player;
            Item held = player.HeldItem;
            if (held.useStyle != ItemUseStyleID.Rapier) {
                if (player.GetModPlayer<BismuthPlayer>().IsEquippedBerserksRing) {
                    player.GetAttackSpeed(DamageClass.Generic) *= 3f;
                }
                if (player.GetModPlayer<BismuthPlayer>().IsEquippedScalyHelmet) {
                    player.GetAttackSpeed(DamageClass.Generic) *= 1.05f;
                }
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 0 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                player.GetAttackSpeed(DamageClass.Ranged) *= 1.05f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 1 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                player.GetAttackSpeed(DamageClass.Ranged) *= 1.10f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 2 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                player.GetAttackSpeed(DamageClass.Ranged) *= 1.15f;
            }
        }
    }
}