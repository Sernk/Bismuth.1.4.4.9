using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace Bismuth.Utilities.Hooks {
    public class Bestiary : ModSystem {
        private static FieldInfo ModField;

        public override void Load() {
            On_ModSourceBestiaryInfoElement.GetFilterImage += On_ModSourceBestiaryInfoElement_GetFilterImage;
            ModField = typeof(ModBestiaryInfoElement).GetField("_mod", BindingFlags.Instance | BindingFlags.NonPublic);
        }
        UIElement On_ModSourceBestiaryInfoElement_GetFilterImage(On_ModSourceBestiaryInfoElement.orig_GetFilterImage orig, ModSourceBestiaryInfoElement self) {
            Asset<Texture2D> asset;
            Mod mod = ModField?.GetValue(self) as Mod;
            if (mod.Name == Mod.Name) {
                asset = mod.Assets.Request<Texture2D>("icon_small_bestiary");
                if (asset.Size() == new Vector2(30)) {
                    return new UIImage(asset) { HAlign = 0.5f, VAlign = 0.5f };
                }
                asset = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow");
                return new UIImageFramed(asset, asset.Frame(16, 5, 0, 4)) { HAlign = 0.5f, VAlign = 0.5f };
            }
            else { return orig(self); }
        }
        public override void Unload() {
            On_ModSourceBestiaryInfoElement.GetFilterImage -= On_ModSourceBestiaryInfoElement_GetFilterImage;
            ModField = null;
        }
    }
}