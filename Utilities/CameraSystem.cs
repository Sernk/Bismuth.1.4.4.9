using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities {
    public class CameraSystem : ModSystem {
        static int focusNpcType = -1;
        static float focusStrength = 0f;
        static bool focusing = false;

        public override void ModifyScreenPosition() {
            if (!focusing) { return; }

            Vector2 playerTarget = Main.LocalPlayer.Center - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f);
            Vector2 finalTarget = playerTarget;

            if (focusing && focusNpcType != -1) {
                int id = NPC.FindFirstNPC(focusNpcType);
                if (id != -1) {
                    NPC npc = Main.npc[id];
                    Vector2 npcTarget = npc.Center - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f);
                    finalTarget = npcTarget;
                    focusStrength = MathHelper.Clamp(focusStrength + 0.03f, 0f, 1f);
                }
                else { focusing = false; }
            }
            else { focusStrength = MathHelper.Clamp(focusStrength - 0.03f, 0f, 1f); }

            Main.screenPosition = Vector2.Lerp(playerTarget, finalTarget, focusStrength);
        }
        public static void FocusOn(int npcType) {
            focusNpcType = npcType;
            focusing = true;
        }
        public static void StopFocus() {
            focusing = false;
        }
    }  
}