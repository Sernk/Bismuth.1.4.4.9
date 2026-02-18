using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities {
    public class TribeTotemBiome : ModBiome {
        public override bool IsBiomeActive(Player player) {
            bool active = player.Center.ToTileCoordinates().X > BismuthWorld.TotemX - 115 && player.Center.ToTileCoordinates().X < BismuthWorld.TotemX + 50 && player.Center.ToTileCoordinates().Y > BismuthWorld.TotemY - 40 && player.Center.ToTileCoordinates().Y < BismuthWorld.TotemY + 40 && BismuthWorld.IsTotemActive;
            player.GetModPlayer<BismuthPlayer>().InTribeTotemZone = active;
            BismuthWorld.NearbyTotemOfCurse = active;
            return active;
        }
    }
}