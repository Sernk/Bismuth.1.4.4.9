using Bismuth.Content.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities.Hooks {
    public class BismuthGenVars: ModSystem {
        public static int DesertVillageLeftBorderX;
        public static int DesertVillageLeftBorderY;
        public static int DesertVillageRightBorderX;
        public static int DesertVillageRightBorderY;

        public override void OnWorldLoad() {
            DesertVillageLeftBorderX = 0;
            DesertVillageLeftBorderY = 0;
            DesertVillageRightBorderX = 0;
            DesertVillageRightBorderY = 0;
        }
        public override void SaveWorldData(TagCompound tag) {
            tag["DesertVillageLeftBorderX"] = DesertVillageLeftBorderX;
            tag["DesertVillageLeftBorderY"] = DesertVillageLeftBorderY;
            tag["DesertVillageRightBorderX"] = DesertVillageRightBorderX;
            tag["DesertVillageRightBorderY"] = DesertVillageRightBorderY;
        }
        public override void LoadWorldData(TagCompound tag) {
            DesertVillageLeftBorderX = tag.GetInt("DesertVillageLeftBorderX");
            DesertVillageLeftBorderY = tag.GetInt("DesertVillageLeftBorderY");
            DesertVillageRightBorderX = tag.GetInt("DesertVillageRightBorderX");
            DesertVillageRightBorderY = tag.GetInt("DesertVillageRightBorderY");
        }
        public override void NetSend(BinaryWriter writer) {
            writer.Write(DesertVillageLeftBorderX);
            writer.Write(DesertVillageLeftBorderY);
            writer.Write(DesertVillageRightBorderX);
            writer.Write(DesertVillageRightBorderY);

        }
        public override void NetReceive(BinaryReader reader) {
            DesertVillageLeftBorderX = reader.ReadInt32();
            DesertVillageLeftBorderY = reader.ReadInt32();
            DesertVillageRightBorderX = reader.ReadInt32();
            DesertVillageRightBorderY = reader.ReadInt32();
        }
        public override void PostUpdateWorld() {
            for (int i = 0; i < 20; i++) {
                WorldGen.PlaceTile(DesertVillageLeftBorderX - 35, DesertVillageLeftBorderY- 43, ModContent.TileType<PapuansPlatform>());
                WorldGen.PlaceTile(DesertVillageRightBorderX - 1, DesertVillageRightBorderX - 43, ModContent.TileType<PapuansPlatform>());
            }
            Main.NewText("111");
        }
    }
}
