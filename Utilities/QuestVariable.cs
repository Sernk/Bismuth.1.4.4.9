using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities {
    public class QuestVariable : ModSystem {
        public static int TombstoneStage;
        public static int SunriseQuest;
        public static int PotionQuest;
        public static int LuceatQuest;
        public static int NewPriestQuest;
        public static int BookOfSecretsQuest;
        public static int ElessarQuest;

        public override void OnWorldLoad() {
            TombstoneStage = 0;
            SunriseQuest = 0;
            PotionQuest = 0;
            LuceatQuest = 0;
            NewPriestQuest = 0;
            BookOfSecretsQuest = 0;
            ElessarQuest = 0;
        }
        public override void SaveWorldData(TagCompound tag) {
            tag["TombstoneStage"] = TombstoneStage;
            tag["SunriseQuest"] = SunriseQuest;
            tag["PotionQuest"] = PotionQuest;
            tag["LuceatQuest"] = LuceatQuest;
            tag["NewPriestQuest"] = NewPriestQuest;
            tag["BookOfSecretsQuest"] = BookOfSecretsQuest;
            tag["ElessarQuest"] = ElessarQuest;
        }
        public override void LoadWorldData(TagCompound tag) {
            TombstoneStage = tag.GetInt("TombstoneStage");
            SunriseQuest = tag.GetInt("SunriseQuest");
            PotionQuest = tag.GetInt("PotionQuest");
            LuceatQuest = tag.GetInt("LuceatQuest");
            NewPriestQuest = tag.GetInt("NewPriestQuest");
            BookOfSecretsQuest = tag.GetInt("BookOfSecretsQuest");
            ElessarQuest = tag.GetInt("ElessarQuest");
        }
        public override void NetSend(BinaryWriter writer) {
            writer.Write(TombstoneStage);
            writer.Write(SunriseQuest);
            writer.Write(PotionQuest);
            writer.Write(LuceatQuest);
            writer.Write(NewPriestQuest);
            writer.Write(BookOfSecretsQuest);
            writer.Write(ElessarQuest);
        }
        public override void NetReceive(BinaryReader reader) {
            TombstoneStage = reader.ReadInt32();
            SunriseQuest = reader.ReadInt32();
            PotionQuest = reader.ReadInt32();
            LuceatQuest = reader.ReadInt32();
            NewPriestQuest = reader.ReadInt32();
            BookOfSecretsQuest = reader.ReadInt32();
            ElessarQuest = reader.ReadInt32();
        }
    }
}
