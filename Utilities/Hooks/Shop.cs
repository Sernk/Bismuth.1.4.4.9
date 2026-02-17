using Bismuth.Utilities.ModSupport.BismuthHooks;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Bismuth.Utilities.Hooks
{
    /// <summary>
    /// Возможно цену можно поменять и по легче но я не знаю как.
    /// Снижает цены у NPC‑продавцов в зависимости от навыков игрока.
    /// </summary>
    public sealed class Shop : ModSystem
    {
        public override void Load()
        {
            On_ShopHelper.GetShoppingSettings += On_ShopHelper_GetShoppingSettings;
        }

        private ShoppingSettings On_ShopHelper_GetShoppingSettings(On_ShopHelper.orig_GetShoppingSettings orig, ShopHelper self, Player player, NPC npc) {
            ShoppingSettings settings = orig(self, player, npc);

            BismuthPlayer bismuth = player.GetModPlayer<BismuthPlayer>();

            if (bismuth.skill132lvl > 0 && npc.type == NPCID.Demolitionist) settings.PriceAdjustment *= 0.6f;
            if (bismuth.skill83lvl > 0) settings.PriceAdjustment *= 0.65f;
            if (bismuth.Charm >= 40) settings.PriceAdjustment *= 0.60f;
            if (bismuth.Charm == 30) settings.PriceAdjustment *= 0.70f;
            if (bismuth.Charm == 20) settings.PriceAdjustment *= 0.80f;
            if (bismuth.Charm == 15) settings.PriceAdjustment *= 0.85f;
            if (bismuth.Charm == 10) settings.PriceAdjustment *= 0.80f;
            if (bismuth.Charm == 5) settings.PriceAdjustment *= 0.95f;
            if (bismuth.Charm == 0) settings.PriceAdjustment *= 1.00f;
            if (bismuth.Charm == -5) settings.PriceAdjustment *= 1.05f;
            if (bismuth.Charm == -10) settings.PriceAdjustment *= 1.10f;
            if (bismuth.Charm == -15) settings.PriceAdjustment *= 1.15f;
            if (bismuth.Charm == -20) settings.PriceAdjustment *= 1.20f;
            if (bismuth.Charm <= -30) settings.PriceAdjustment *= 1.30f;

            return settings;
        }
        public override void Unload() {
            On_ShopHelper.GetShoppingSettings -= On_ShopHelper_GetShoppingSettings;
        }
    }
}