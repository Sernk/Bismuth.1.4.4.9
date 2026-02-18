using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class LocalizationSystem : ModSystem, ILocalizedModType
    {
        public string LocalizationCategory => "CoinSystem";

        public string DwarvenCoin => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.DwarvenCoin");
        public string Ocrea => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.Ocrea");
        public string ImperianHelmet => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.ImperianHelmet");
        public string Lorica => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.Lorica");
        public string AetherRecipe => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.AetherRecipe");
        public string GalvornRecipe => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.GalvornRecipe");
        public string PoisonRecipe => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.PoisonRecipe");
        public string PanaceaRecipe => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.PanaceaRecipe");
        public string PhilosopherStone => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.PhilosopherStone");
        public string SoulScytheRecipe => Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.SoulScytheRecipe");
        public static string Necromant = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.Necromant");

        public static int GetProgress()
        {
            int progress = 0;
            if (NPC.downedBoss1) progress++; // Глаз
            if (NPC.downedBoss2) progress++; // Мозг или Червь
            if (NPC.downedBoss3) progress++; // Скелетрон
            if (Main.hardMode) progress++; // Хардмод
            if (NPC.downedMechBossAny) progress++; // Любой механический босс
            if (NPC.downedPlantBoss) progress++; // Плантер
            if (NPC.downedGolemBoss) progress++; // Голем
            return progress;
        }
    }
}