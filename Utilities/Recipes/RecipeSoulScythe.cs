using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Recipes {
    public class RecipeSoulScythe {
        public static Condition SoulScythe = new(ModContent.GetInstance<LocalizationSystem>().SoulScytheRecipe, () => BismuthWorld.SoulScytheRecipe);
    }
}
