using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bismuth.BismuthLayerInPlayer
{
    public class BatLayer : ModPlayer
    {
        public override void HideDrawLayers(PlayerDrawSet drawInfo)
        {
            if (Player == null || !Player.active) {
                return;
            }
            for (int i = 0; i < drawInfo.DrawDataCache.Count; i++)
            {
                DrawData data = drawInfo.DrawDataCache[i];
                data.sourceRect = Rectangle.Empty;
                drawInfo.DrawDataCache[i] = data;
            }
        }
        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            if (Player == null || !Player.active) {
                return;
            }
            if (HotKeyPlayer.Transform)
            {
                drawInfo.mountOffSet = 0f;
                drawInfo.drawPlayer.invis = true;
                drawInfo.colorArmorBody = Color.Transparent;
                drawInfo.colorArmorHead = Color.Transparent;
                drawInfo.colorArmorLegs = Color.Transparent;
                drawInfo.colorBodySkin = Color.Transparent;
                drawInfo.colorEyeWhites = Color.Transparent;
                drawInfo.colorEyes = Color.Transparent;
                drawInfo.colorHair = Color.Transparent;
                drawInfo.headGlowColor = Color.Transparent;
                drawInfo.headGlowColor = Color.Transparent;
            }
            else
            {
                base.ModifyDrawInfo(ref drawInfo);
                return;
            }
        }
        public override void PostUpdate()
        {
            if (Player == null || !Player.active) {
                return;
            }
            if (HotKeyPlayer.Transform)
            {
                Player.noItems = true;
            }
            else
            {
                base.PostUpdate();
                return;
            }
        }
        //protected override void PreDraw(ref PlayerDrawSet drawInfo)
        //{
        //    List<PlayerDrawLayer> Layer = new List<PlayerDrawLayer>();
        //    drawInfo.drawPlayer.invis = true;
        //    ModifyDrawLayers(Layer);
        //}

        //void ModifyDrawLayers(List<PlayerDrawLayer> layers)
        //{
        //    layers.RemoveAll(layer =>layer.Name.Contains("Head") ||   layer.Name.Contains("Body") || layer.Name.Contains("Legs") ||layer.Name.Contains("HandsOn") || layer.Name.Contains("HandsOff") || layer.Name.Contains("Back") || layer.Name.Contains("Front") ||layer.Name.Contains("Shoes") || layer.Name.Contains("Waist") || layer.Name.Contains("Wings") || layer.Name.Contains("Shield") || layer.Name.Contains("Balloon") || layer.Name.Contains("Neck") || layer.Name.Contains("Face") || layer.Name.Contains("Beard"));
        //}

        //protected override void PostDraw(ref PlayerDrawSet drawInfo)
        //{
        //    Player player = drawInfo.drawPlayer;
        //    Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Content/Mounts/VampireBatMount_Back2").Value;

        //    Vector2 position = player.MountedCenter - Main.screenPosition;

        //    float scale = 32f / texture.Width;

        //    Main.EntitySpriteDraw(texture, position, null, Color.White, player.fullRotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0);
        //}
    }
}
