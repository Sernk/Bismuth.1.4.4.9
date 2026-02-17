using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Recipes
{
    public static class PoisonRecipe
    {
        public static Condition PoisonRecipes = new(ModContent.GetInstance<LocalizationSystem>().PoisonRecipe, () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().ZoneSwamp);
    }
}