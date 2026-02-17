using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Utilities;
using Bismuth.Utilities.ModSupport;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs {
    [AutoloadHead]
    public class OldmanPriest : ModNPC {
        public override void Load() {
            _ = this.GetLocalization("Chat.OldmanPriestAnsv_1").Value; // Ru: Благословение En: Blessing

            _ = this.GetLocalization("Chat.OldmanPriestNQ_1").Value; // Ru: Да благословит тебя Юпитер, герой! En: Jupiter bless you, hero!
            _ = this.GetLocalization("Chat.OldmanPriestNQ_2").Value; // Ru: Время лечит, но священники быстрее. En: Time heals, but the priests are faster.
            _ = this.GetLocalization("Chat.OldmanPriestNQ_3").Value; // Ru: После исчезновения некроманта в городе стало гораздо лучше. Прямо как в былые времена
                                                                     // En: It's gotten a lot better here after the Necromancer got driven out. Just like the good old times.
            _ = this.GetLocalization("Chat.OldmanPriestNQ_4").Value; // Ru: Ты хочешь сказать, что не считаешь антропомантию самым точным способом предсказывать погоду?
                                                                     // En: Don't you think that anthropomancy is the most precise forecasting method?
            _ = this.GetLocalization("Chat.OldmanPriestNQ_6").Value; // Ru: Я благословляю тебя En: I'm blessing you
            _ = this.GetLocalization("Chat.OldmanPriestNQ_7").Value; // Ru: Извини, но ты можешь получить благословение лишь раз в сутки 
                                                                     // En: Sorry, but you can't be blessed more than once a day
        }
        public override void SetStaticDefaults() => NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        public override List<string> SetNPCNameList() => [Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname];
        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 32;
            NPC.height = 42;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
        }
        public override void SetChatButtons(ref string button, ref string button2) {
            string OldmanPriestAnsv_1 = this.GetLocalization("Chat.OldmanPriestAnsv_1").Value;

            Player player = Main.LocalPlayer;
            IQuest quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.OldmanPriest).FirstOrDefault();

            if (quest != null) { button = quest.GetButtonText(player); }
            if (quest == null) { button = Lang.inter[28].Value; }
            button2 = OldmanPriestAnsv_1;
        }
        public override string GetChat() {
            string OldmanPriestNQ_1 = this.GetLocalization("Chat.OldmanPriestNQ_1").Value;
            string OldmanPriestNQ_2 = this.GetLocalization("Chat.OldmanPriestNQ_2").Value;
            string OldmanPriestNQ_3 = this.GetLocalization("Chat.OldmanPriestNQ_3").Value;
            string OldmanPriestNQ_4 = this.GetLocalization("Chat.OldmanPriestNQ_4").Value;

            Player player = Main.LocalPlayer;
            IQuest quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.OldmanPriest).FirstOrDefault();

            if (quest != null) { return quest.GetChat(NPC, player); }

            return WorldGen.genRand.Next(0, 4) switch {
                0 => OldmanPriestNQ_1,
                1 => OldmanPriestNQ_2,
                2 => OldmanPriestNQ_3,
                _ => OldmanPriestNQ_4,
            };
        }
        public override bool CheckConditions(int left, int right, int top, int bottom) => false;
        public override void AddShops() {
            Condition KilledWoF = Condition.Hardmode;
            Condition DownedSkeletron = Condition.DownedSkeletron;
            Condition DownedPirates = Condition.DownedPirates;

            NPCShop shop = new(Type, "OldmanPriestShop");

            shop.Add(ModContent.ItemType<SacrificialDagger>());
            shop.Add(ModContent.ItemType<BottleOfIncense>());
            shop.Add(ModContent.ItemType<FaithTreatise>(), DownedSkeletron);
            shop.Add(ModContent.ItemType<Sanctus>(), KilledWoF);
            shop.Add(ModContent.ItemType<HolyGrail>(), DownedPirates);

            shop.Add(new Item(ModContent.ItemType<PaladinsMask>()) {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.ImperianHelmetID
            }, DownedSkeletron);
            shop.Add(new Item(ModContent.ItemType<PaladinsShell>()) {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.LoricaID
            }, DownedSkeletron);
            shop.Add(new Item(ModContent.ItemType<PaladinsLeggings>()) {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.OcreaID
            }, DownedSkeletron);

            shop.Register();
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
            string OldmanPriestNQ_6 = this.GetLocalization("Chat.OldmanPriestNQ_6").Value;
            string OldmanPriestNQ_7 = this.GetLocalization("Chat.OldmanPriestNQ_7").Value;

            if (firstButton) { shopName = "OldmanPriestShop"; }
            Player player = Main.LocalPlayer;
            IQuest quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.OldmanPriest).FirstOrDefault();
            if (quest != null) { quest?.OnChatButtonClicked(player); }
            else {
                if (Main.LocalPlayer.FindBuffIndex(ModContent.BuffType<Blessing>()) == -1) {
                    Main.npcChatText = OldmanPriestNQ_6;
                    Main.LocalPlayer.AddBuff(ModContent.BuffType<Blessing>(), 18000);
                }
                else { Main.npcChatText = OldmanPriestNQ_7; }
            }
        }
        public void UpdatePosition() => NPC.spriteDirection = Main.LocalPlayer.position.X >= NPC.position.X ? 1 : -1;
        public override void AI() {
            if (!NPC.HasGivenName) { NPC.GivenName = Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname; }
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1) {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.oldVelocity.X != 0f) { NPC.velocity.X = 0f; }
            if (Main.LocalPlayer.talkNPC != -1) { if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI) { UpdatePosition(); } }
        }
    }
}