using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class TribeTotemBiome : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            if (BiomeTileCounterSystem.ZoneTotem >= 1)
            {
                TotemOfCurse.NearbyTotemOfCurse = true;
                return false;
            }
            else
            {
                TotemOfCurse.NearbyTotemOfCurse = false;
                return false;
            }
        }
    }
}