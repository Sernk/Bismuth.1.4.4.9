using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities {
    public class TempNPCs : ModSystem {
        const int Temp = 18000; // 5 минут = 300 сек * 60 тиков
        const int Temp2 = 3600; // 1 минут = 60 сек  * 60 тиков
        public static double LastTemp = 0;

        public static bool AlchemistTemp = false;
        public static bool AlchemistTempStart = false;
        public static bool WaitStoneQuestsTemp = false;
        public static bool WaitStoneQuestsTempStart = false;
        public static bool PhilosopherStoneQuestsTemp = false;
        public static bool PhilosopherStoneQuestsTempStart = false;
        public static bool RecipePhilosopherStone = false;
        public static bool BabaYagaTemp = false;
        public static bool BabaYagaTempStart = false;
        public static bool BueBegger = false;
        public static bool AlchemistPreSkeletonNewQuest = false;
        public static bool AlchemistNewQuest = false;
        public static bool BeggarNewQuest = false;
        public static bool DwarfBlacksmithNewQuest = false;
        public static bool ImperianCommanderNewQuest = false;
        public static bool ImperianConsulNewQuest = false;
        public static bool BabaYagaNewQuest = false;

        public override void PostUpdateWorld() {
            //ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral($"{Main.GameUpdateCount - LastTemp} {Temp2}"), Color.LightGray, -1);
            if (AlchemistTempStart) {
                if (Main.GameUpdateCount - LastTemp >= Temp2) {
                    AlchemistTemp = true;
                    AlchemistTempStart = false;
                    LastTemp = Main.GameUpdateCount;
                }
            }
            if (WaitStoneQuestsTempStart) {
                if (Main.GameUpdateCount - LastTemp >= Temp2) {
                    WaitStoneQuestsTemp = true;
                    WaitStoneQuestsTempStart = false;
                    LastTemp = Main.GameUpdateCount;
                }
            }
            if (PhilosopherStoneQuestsTempStart) {
                if (Main.GameUpdateCount - LastTemp >= Temp2) {
                    PhilosopherStoneQuestsTemp = true;
                    PhilosopherStoneQuestsTempStart = false;
                    LastTemp = Main.GameUpdateCount;
                }
            }
            if (BabaYagaTempStart) {
                if (Main.GameUpdateCount - LastTemp >= Temp2) {
                    BabaYagaTemp = true;
                    BabaYagaTempStart = false;
                    LastTemp = Main.GameUpdateCount;
                }
            }
        }
        #region Save tag
        public override void SaveWorldData(TagCompound tag) {
            tag["AlchemistTemp"] = AlchemistTemp;
            tag["AlchemistTempStart"] = AlchemistTempStart;
            tag["WaitStoneQuestsTemp"] = WaitStoneQuestsTemp;
            tag["WaitStoneQuestsTempStart"] = WaitStoneQuestsTempStart;
            tag["PhilosopherStoneQuestsTemp"] = PhilosopherStoneQuestsTemp;
            tag["PhilosopherStoneQuestsTempStart"] = PhilosopherStoneQuestsTempStart;
            tag["RecipePhilosopherStone"] = RecipePhilosopherStone;
            tag["BabaYagaTemp"] = BabaYagaTemp;
            tag["BabaYagaTempStart"] = BabaYagaTempStart;
            tag["BueBegger"] = BueBegger;
            tag["AlchemistPreSkeletonNewQuest"] = AlchemistPreSkeletonNewQuest;
            tag["AlchemistNewQuest"] = AlchemistNewQuest;
            tag["BeggarNewQuest"] = BeggarNewQuest;
            tag["DwarfBlacksmithNewQuest"] = DwarfBlacksmithNewQuest;
            tag["ImperianCommanderNewQuest"] = ImperianCommanderNewQuest;
            tag["ImperianConsulNewQuest"] = ImperianConsulNewQuest;
            tag["BabaYagaNewQuest"] = BabaYagaNewQuest;
            tag["LastTemp"] = LastTemp;
        }
        public override void LoadWorldData(TagCompound tag) {
            AlchemistTemp = tag.GetBool("AlchemistTemp");
            AlchemistTempStart = tag.GetBool("AlchemistTempStart");
            WaitStoneQuestsTemp = tag.GetBool("WaitStoneQuestsTemp");
            WaitStoneQuestsTempStart = tag.GetBool("WaitStoneQuestsTempStart");
            PhilosopherStoneQuestsTempStart = tag.GetBool("PhilosopherStoneQuestsTempStart");
            PhilosopherStoneQuestsTemp = tag.GetBool("PhilosopherStoneQuestsTemp");
            RecipePhilosopherStone = tag.GetBool("RecipePhilosopherStone");
            BabaYagaTemp = tag.GetBool("BabaYagaTemp");
            BabaYagaTempStart = tag.GetBool("BabaYagaTempStart");
            BueBegger = tag.GetBool("BueBegger");
            AlchemistPreSkeletonNewQuest = tag.GetBool("AlchemistPreSkeletonNewQuest");
            AlchemistNewQuest = tag.GetBool("AlchemistNewQuest");
            BeggarNewQuest = tag.GetBool("BeggarNewQuest");
            DwarfBlacksmithNewQuest = tag.GetBool("DwarfBlacksmithNewQuest");
            ImperianCommanderNewQuest = tag.GetBool("ImperianCommanderNewQuest");
            ImperianConsulNewQuest = tag.GetBool("ImperianConsulNewQuest");
            BabaYagaNewQuest = tag.GetBool("BabaYagaNewQuest");

            LastTemp = tag.GetDouble("LastTemp");
        }
        public override void OnWorldLoad() {
            AlchemistTemp = false;
            AlchemistTempStart = false;
            WaitStoneQuestsTemp = false;
            WaitStoneQuestsTempStart = false;
            PhilosopherStoneQuestsTemp = false;
            PhilosopherStoneQuestsTempStart = false;
            RecipePhilosopherStone = false;
            BabaYagaTemp = false;
            BabaYagaTempStart = false;
            BueBegger = false;
            AlchemistPreSkeletonNewQuest = false;
            AlchemistNewQuest = false;
            BeggarNewQuest = false;
            DwarfBlacksmithNewQuest = false;
            ImperianCommanderNewQuest = false;
            ImperianConsulNewQuest = false;
            BabaYagaNewQuest = false;
            LastTemp = 0;
        }
        public override void NetSend(BinaryWriter writer) {
            writer.Write(AlchemistTemp);
            writer.Write(AlchemistTempStart);
            writer.Write(WaitStoneQuestsTemp);
            writer.Write(WaitStoneQuestsTempStart);
            writer.Write(PhilosopherStoneQuestsTemp);
            writer.Write(PhilosopherStoneQuestsTempStart);
            writer.Write(RecipePhilosopherStone);
            writer.Write(BabaYagaTemp);
            writer.Write(BabaYagaTempStart);
            writer.Write(BueBegger);
            writer.Write(AlchemistPreSkeletonNewQuest);
            writer.Write(AlchemistNewQuest);
            writer.Write(BeggarNewQuest);
            writer.Write(DwarfBlacksmithNewQuest);
            writer.Write(ImperianCommanderNewQuest);
            writer.Write(ImperianConsulNewQuest);
            writer.Write(BabaYagaNewQuest);
            writer.Write(LastTemp);
        }
        public override void NetReceive(BinaryReader reader) {
            AlchemistTemp = reader.ReadBoolean();
            AlchemistTempStart = reader.ReadBoolean();
            WaitStoneQuestsTemp = reader.ReadBoolean();
            WaitStoneQuestsTempStart = reader.ReadBoolean();
            PhilosopherStoneQuestsTemp = reader.ReadBoolean();
            PhilosopherStoneQuestsTempStart = reader.ReadBoolean();
            RecipePhilosopherStone = reader.ReadBoolean();
            BabaYagaTemp = reader.ReadBoolean();
            BabaYagaTempStart = reader.ReadBoolean();
            BueBegger = reader.ReadBoolean();
            AlchemistPreSkeletonNewQuest = reader.ReadBoolean();
            AlchemistNewQuest = reader.ReadBoolean();
            BeggarNewQuest = reader.ReadBoolean();
            DwarfBlacksmithNewQuest = reader.ReadBoolean();
            ImperianCommanderNewQuest = reader.ReadBoolean();
            ImperianConsulNewQuest = reader.ReadBoolean();
            BabaYagaNewQuest = reader.ReadBoolean();
            LastTemp = reader.ReadDouble();
        } 
        #endregion
    }
}