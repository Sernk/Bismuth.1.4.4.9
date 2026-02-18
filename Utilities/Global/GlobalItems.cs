using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Other;
using Bismuth.Content.NPCs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalItems : GlobalItem, ILocalizedModType
    {
        public string LocalizationCategory => "BonusArmor";
        public bool IsInfoItem = false;

        public override bool InstancePerEntity { get { return true; } }
        public override void Load()
        {
            _ = this.GetLocalization("Ninja.NinjaHood").Value;
            _ = this.GetLocalization("Ninja.NinjaPants").Value;
            _ = this.GetLocalization("Ninja.NinjaShirt").Value;

            _ = this.GetLocalization("Fossil.FossilHelm").Value;
            _ = this.GetLocalization("Fossil.FossilPants").Value;
            _ = this.GetLocalization("Fossil.FossilShirt").Value;

            _ = this.GetLocalization("Info.Unboundltips").Value;
            _ = this.GetLocalization("Info.BaseTooltips").Value;
            _ = this.GetLocalization("Info.BaseRingTooltips").Value;
            _ = this.GetLocalization("Info.TheRingOfTheBloodTooltips").Value;
            _ = this.GetLocalization("Info.TheRingOfTheSeasTooltips").Value;
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (player.FindBuffIndex(ModContent.BuffType<FearOfMaze>()) != -1 && item.hammer > 0)
            {
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<DicePlaying>()) != -1)
            {
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<VampireBat>()) != -1)
            {
                return false;
            }
            return base.CanUseItem(item, player);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string NinjaHood = this.GetLocalization("Ninja.NinjaHood").Value;
            string NinjaPants = this.GetLocalization("Ninja.NinjaPants").Value;
            string NinjaShirt = this.GetLocalization("Ninja.NinjaShirt").Value;

            string FossilHelm = this.GetLocalization("Fossil.FossilHelm").Value;
            string FossilPants = this.GetLocalization("Fossil.FossilPants").Value;
            string FossilShirt = this.GetLocalization("Fossil.FossilShirt").Value;
            // Fossil armor tooltips
            if (item.type == ItemID.FossilHelm) tooltips[3].Text = FossilHelm;
            if (item.type == ItemID.FossilPants) tooltips[3].Text = FossilPants;
            if (item.type == ItemID.FossilShirt) tooltips[3].Text = FossilShirt;
            // Ninja armor tooltips
            if (item.type == ItemID.NinjaHood) tooltips[3].Text = NinjaHood;
            if (item.type == ItemID.NinjaPants) tooltips[3].Text = NinjaPants;
            if (item.type == ItemID.NinjaShirt) tooltips[3].Text = NinjaShirt;

            int Alchemist = NPC.FindFirstNPC(ModContent.NPCType<Alchemist>());
            string PotionName = Lang.GetItemName(ModContent.ItemType<PotionOfHumanity>()).Value;

            string Unboundltips = this.GetLocalization("Info.Unboundltips").Value;
            string Base = this.GetLocalization("Info.BaseTooltips").Value;
            string BaseRing = this.GetLocalization("Info.BaseRingTooltips").Value;
            string alchemistName = Alchemist != -1 ? Main.npc[Alchemist].GivenName : Lang.GetNPCNameValue(ModContent.NPCType<Alchemist>());
            string BaseRing2 = string.Format(BaseRing, PotionName, alchemistName);
            string TheRingOfTheBlood = this.GetLocalization("Info.TheRingOfTheBloodTooltips").Value;
            string TheRingOfTheSeas = this.GetLocalization("Info.TheRingOfTheSeasTooltips").Value;

            List<string> keys = Bismuth.InfoAcc.GetAssignedKeys();
            string keyName = keys.Count > 0 ? keys[0] : Unboundltips;
            string text = string.Format(Base, keyName);

            if (IsInfoItem)
            {
                if (Main.LocalPlayer.GetModPlayer<HotKeyPlayer>().InfoAcc == false) tooltips.Add(new TooltipLine(Mod, "SetBonus:AwakenedTip", text) { OverrideColor = Color.Gray });
                else
                {
                    if (item.type == ModContent.ItemType<TheRingOfTheBlood>()) tooltips.Add(new TooltipLine(Mod, "SetBonus:AwakenedTip", string.Format(TheRingOfTheBlood, BaseRing2)) { OverrideColor = Color.IndianRed });
                    if (item.type == ModContent.ItemType<TheRingOfTheSeas>()) tooltips.Add(new TooltipLine(Mod, "SetBonus:AwakenedTip", string.Format(TheRingOfTheSeas, BaseRing2)) { OverrideColor = Color.LawnGreen });
                }
            }
        }
        public static int HealBost(int Base, int Factor)
        {
            int bonus = Base + Factor;
            return bonus;
        }
        public override void SetDefaults(Item entity)
        {
            base.SetDefaults(entity);
        }
        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue)
        {
            BismuthPlayer BismuthPlayer = Main.LocalPlayer.GetModPlayer<BismuthPlayer>();

            int progress = LocalizationSystem.GetProgress();

            if (BismuthPlayer.IsEquippedAthenasShield)
            {
                if (progress >= 3)
                {
                    if (item.type == ItemID.LesserHealingPotion) { healValue = HealBost(50, 15); }
                    if (item.type == ItemID.HealingPotion) { healValue = HealBost(100, 30); }
                    if (item.type == ItemID.GreaterHealingPotion) { healValue = HealBost(150, 45); }
                    if (item.type == ItemID.SuperHealingPotion) {healValue = HealBost(200, 60); }
                    if (item.type == ItemID.RestorationPotion) { healValue = HealBost(90, 25); }
                }
            }
        }
        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.FossilHelm)
            {
                player.GetCritChance(DamageClass.Ranged) -= 4;
                player.ThrownVelocity += 0.12f;
            }
            if (item.type == ItemID.FossilPants)
            {
                player.GetCritChance(DamageClass.Ranged) -= 5;
                player.GetCritChance(DamageClass.Throwing) += 10;
            }
            if (item.type == ItemID.FossilShirt)
            {
                player.GetCritChance(DamageClass.Ranged) -= 4;
                player.GetDamage(DamageClass.Throwing) += 0.12f;
            }
            if (item.type == ItemID.NinjaHood)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.ThrownVelocity += 0.09f;
            }
            if (item.type == ItemID.NinjaPants)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.GetCritChance(DamageClass.Throwing) += 7;
            }
            if (item.type == ItemID.NinjaShirt)
            {
                player.GetCritChance(DamageClass.Generic) -= 3;
                player.GetDamage(DamageClass.Throwing) += 0.09f;
            }
        }
        //public override void SetStaticDefaults()
        //{
        //    ItemID.Sets.ExtractinatorMode[ItemID.SiltBlock] = ItemID.SiltBlock; // Без этого не работает ExtractinatorUse();
        //}
        //public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        //{
        //    if (extractType == ItemID.SiltBlock)
        //    {
        //        if (Main.rand.Next(25) == 0)
        //        {
        //            resultType = ModContent.ItemType<DwarvenCoin>();
        //            resultStack = 1;
        //        }
        //    }
        //}
    }
}