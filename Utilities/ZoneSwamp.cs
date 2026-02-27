using Bismuth.Backgrounds;
using Bismuth.Waters;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class ZoneSwamp : ModBiome
    {
        public override bool IsBiomeActive(Player player) {
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
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Demo");
        public override string BestiaryIcon => "Bismuth/Glow/SwampBiomeIcon";
        public override string BackgroundPath => "Bismuth/Glow/Swamp_bestiary_bg";
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ZoneSwampBgStyle>();
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<SwampWaterStyle>();
    }
}
