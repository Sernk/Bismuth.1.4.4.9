using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs {
    public class AlchemistDeath : ModNPC {
        public int tick = 0;
        public int currentframe = 0;

        public override void SetDefaults() {
            NPC.width = 90;
            NPC.height = 48;
            NPC.lifeMax = 10;
            NPC.dontTakeDamage = true;
            NPC.dontCountMe = true;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
        }
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 18;
        }
        public override void AI() {

            NPC.direction = (int)NPC.ai[0];
            NPC.spriteDirection = (int)NPC.ai[0];

            tick++;
            if (currentframe <= 17 && tick > 5) {
                currentframe++;
                tick = 0;
            }
            if (tick > 120) {
                NPC.life = -1;
                NPC.checkDead();
                NPC.HitInfo hitInfo = new() { Damage = 9999 };
                HitEffect(hitInfo);
            }
            NPC.velocity.Y = 4f;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/AlchemistDeath").Value, NPC.position - Main.screenPosition + new Vector2(NPC.spriteDirection == 1 ? 46f : -20f, 4f), new Rectangle?(new Rectangle(0, currentframe * 48, 90, 48)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            return false;
        }
        public override void HitEffect(NPC.HitInfo hit) {
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0) {
                for (int i = 0; i < 5; i++) {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.Center, NPC.velocity,  Main.rand.Next(11, 14), Main.rand.NextFloat(0.5f, 1f));
                }
            }
        }
        public override void OnKill() {
            CameraSystem.StopFocus();
            Item.NewItem(NPC.GetSource_Death(), (int)NPC.Center.X + (NPC.direction == -1 ? - 50 : 50), (int)NPC.Center.Y, NPC.width, NPC.height, ModContent.ItemType<PoisonFlask>(), Main.rand.Next(5, 10));
        }
    }
}