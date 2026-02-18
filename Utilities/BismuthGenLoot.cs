using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities {
    public class BismuthGenLoot {
        public static void GenerateBiomeRedChestLoot(Item[] chestInventory, int RedcurrentIndex) {
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<AriadnesTangle>(), ModContent.ItemType<PrometheusFire>())); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(ModContent.ItemType<AthenasShield>()); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(ModContent.ItemType<TheMoldofaKeyOfTheSun>()); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[RedcurrentIndex].stack = Main.rand.Next(3, 11); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.ApprenticeBait, ItemID.JourneymanBait, ItemID.MasterBait)); chestInventory[RedcurrentIndex].stack = Main.rand.Next(4, 9); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[RedcurrentIndex].stack = Main.rand.Next(2, 5); RedcurrentIndex++;
        }
        public static void GenerateBiomeBlueChestLoot(Item[] chestInventory, int BluecurrentIndex) {
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<WingsOfDaedalus>(), ModContent.ItemType<GoldenRune>())); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(ModContent.ItemType<RedKey>()); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[BluecurrentIndex].stack = Main.rand.Next(3, 11); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.HunterPotion, ItemID.ShinePotion)); chestInventory[BluecurrentIndex].stack = Main.rand.Next(2, 4); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[BluecurrentIndex].stack = Main.rand.Next(2, 5); BluecurrentIndex++;
        }
        public static void GenerateBiomeGreenChestLoot(Item[] chestInventory, int GreencurrentIndex) {
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<QuiverOfOdysseus>(), ModContent.ItemType<BowOfOdysseus>())); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(ModContent.ItemType<BlueKey>()); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[GreencurrentIndex].stack = Main.rand.Next(3, 11); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.RegenerationPotion, ItemID.IronskinPotion)); chestInventory[GreencurrentIndex].stack = Main.rand.Next(1, 3); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[GreencurrentIndex].stack = Main.rand.Next(2, 5); GreencurrentIndex++;
        }
    }
}