using Bismuth.Backgrounds;
using Bismuth.Waters;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class ZoneSwamp : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            bool inSwamp = BiomeTileCounterSystem.ZoneSwampBiom > 150;
            player.GetModPlayer<BismuthPlayer>().ZoneSwamp = inSwamp;
            return inSwamp;
        }
        public override void SpecialVisuals(Player player, bool isActive) {
            if (isActive) {
                if (!Filters.Scene["Bismuth:SwampSky"].IsActive()) {
                    Filters.Scene.Activate("Bismuth:SwampSky", default);
                }
            }
            else if (Filters.Scene["Bismuth:SwampSky"].IsActive()) {
                Filters.Scene.Deactivate("Bismuth:SwampSky");
            }
        }
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
        public override int Music => MusicID.UndergroundCrimson;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ZoneSwampBgStyle>();
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<SwampWaterStyle>();
    }
}
