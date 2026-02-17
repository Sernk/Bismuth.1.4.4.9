using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Placeable;
using Bismuth.Utilities;
using Bismuth.Utilities.ModSupport;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs {
    //[AutoloadHead]
    public class BabaYaga : ModNPC {
        public override void Load() {
            _ = this.GetLocalization("Chat.SwampWitchName_1").Value; //Ru: Хагата En: Hagata
            _ = this.GetLocalization("Chat.SwampWitchName_2").Value; //Ru: Пряха En: Priaha
            _ = this.GetLocalization("Chat.SwampWitchName_3").Value; //Ru: Шептуха En: Whispera
            _ = this.GetLocalization("Chat.SwampWitchName_4").Value; //Ru: Тельза En: Telsa
            _ = this.GetLocalization("Chat.SwampWitchName_5").Value; //Ru: Флемет En: Flemet

            _ = this.GetLocalization("Chat.SwampWitchAnsv_1").Value; //Ru: Что вам нужно от меня? En: What do you need from me?
            _ = this.GetLocalization("Chat.SwampWitchAnsv_2").Value; //Ru: Думаю, я справлюсь En: I think I can do it
            _ = this.GetLocalization("Chat.SwampWitchAnsv_3").Value; //Ru: Фолиант у меня En: I found the book
            _ = this.GetLocalization("Chat.SwampWitchAnsv_3_2").Value; // Ru: Я продолжу поиски En: I'll continue my searches
            _ = this.GetLocalization("Chat.SwampWitchAnsv_4").Value; //Ru: Как продвигаются исследования? En: How's research going?
            _ = this.GetLocalization("Chat.SwampWitchAnsv_5").Value; //Ru: Где спрятан этот камень? En: Where can I find the stone?
            _ = this.GetLocalization("Chat.SwampWitchAnsv_6").Value; //Ru: Я достану камень! En: I'll get the stone!
            _ = this.GetLocalization("Chat.SwampWitchAnsv_7").Value; //Ru: Да, вот он En: Yes, take it
            _ = this.GetLocalization("Chat.SwampWitchAnsv_8").Value; //Ru: Это сложнее, чем кажется En: It is harder than it looks
            _ = this.GetLocalization("Chat.SwampWitchAnsv_9").Value; //Ru: Я оставлю его себе En: Yes, but you don't deserve it
            _ = this.GetLocalization("Chat.SwampWitchAnsv_10").Value; //Ru: Я заберу твою жизнь! En: Be ready to lose your life!

            _ = this.GetLocalization("Chat.SwampWitch_1").Value; // Ru: Юный герой... Я знала, что ты придешь... Остановись же и выслушай меня, и я клянусь - ты будешь вознагражден En: Young hero… I knew you’d come… Hear me out, I swear - you will not regret it
            _ = this.GetLocalization("Chat.SwampWitch_3").Value; // Ru: Ты уже принес книгу? En: Have you brought the book?
            _ = this.GetLocalization("Chat.SwampWitch_4").Value; // Ru: Мне нужна книга, чтобы продолжить мои исследования. En: I need the book to continue my research.
            _ = this.GetLocalization("Chat.SwampWitch_6").Value; // Ru: Мои исследования ещё не завершены - приходи позже. En: My research is not yet over – come back later.
            _ = this.GetLocalization("Chat.SwampWitch_7").Value; // Ru: А, это ты! Как раз вовремя - я только закончила чтение манускрипта. Теперь ничто не помешает тебе заполучить камень. En: Ah, if it isn’t the young hero! You’re right on time – I just finished reading the tome. Now nothing is going to stop you from getting the stone.
            _ = this.GetLocalization("Chat.SwampWitch_9").Value; // Ru: Как продвигаются поиски камня? En: Did you find the stone?
            _ = this.GetLocalization("Chat.SwampWitch_10").Value; // Ru: Принеси мне камень - и ты будешь вознагражден En: Bring me the stone – and you’ll be rewarded.
            _ = this.GetLocalization("Chat.SwampWitch_12").Value; //Ru: Отличная работа, юный герой! Я держу своё слово - эти зелья помогут тебе уберечься от множества ядов и болезней. Если тебе понадобятся ещё - ты всегда можешь купить их у меня. En: Excellent work, young hero! I stay true to my word – these potions will keep you safe from many poisons and diseases. If you need more – you can always buy them here.

            _ = this.GetLocalization("Chat.SwampWitchNQ_1").Value; // Ru: Щепотка поганки, каблук башмака... En: Pinch of deathcup, heel of shoe
            _ = this.GetLocalization("Chat.SwampWitchNQ_2").Value; // Ru: Да поможет тебе магия, герой.. En: Let the magic guide you, hero.
            _ = this.GetLocalization("Chat.SwampWitchNQ_3").Value; // Ru: Кто такой {0}? Его магия сильна. En: Who is {0}? His magic is strong.
            _ = this.GetLocalization("Chat.SwampWitchNQ_4").Value; // Ru: Ты не видел нигде серебряных туфелек? En: Have you seen silver shoes around anywhere?
        }
        public override void SetStaticDefaults() {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 26;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            var quests = QuestRegistry.GetAvailableQuests(Main.LocalPlayer, "BabaYaga");
            bool showAvailable = Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest <= 10 || (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && TempNPCs.BabaYagaTemp && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest <= 10);
            bool showActive = (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 100);

            foreach (var quest in quests) {
                quest.IsActiveQuestUIIcon(showAvailable, showActive, spriteBatch, NPC, Main.LocalPlayer);
            }
            if (!quests.Any()) {
                Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
                Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;

                if (showAvailable) {
                    spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(8, -34), Color.White);
                }
                if (showActive) {
                    spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(4, -38), Color.White);
                }
            }
        }
        public override string GetChat() {
            Player player = Main.LocalPlayer;
            var quests = player.GetModPlayer<Quests>();
            string SwampWitch_1 = this.GetLocalization("Chat.SwampWitch_1").Value;
            string SwampWitch_3 = this.GetLocalization("Chat.SwampWitch_3").Value;
            string SwampWitch_7 = this.GetLocalization("Chat.SwampWitch_7").Value;
            string SwampWitch_9 = this.GetLocalization("Chat.SwampWitch_9").Value;
            string SwampWitchNQ_1 = this.GetLocalization("Chat.SwampWitchNQ_1").Value;
            string SwampWitchNQ_2 = this.GetLocalization("Chat.SwampWitchNQ_2").Value;
            string SwampWitchNQ_4 = this.GetLocalization("Chat.SwampWitchNQ_4").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 0) { return SwampWitch_1; }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 20) { return SwampWitch_3; }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 0 && TempNPCs.BabaYagaTemp) { return SwampWitch_7; }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20) { return SwampWitch_9; }
            else {
                IQuest quest = QuestRegistry.GetAvailableQuests(player, "BabaYaga").FirstOrDefault();

                if (TempNPCs.BabaYagaNewQuest && quest != null) return quest.GetChat(NPC, player);

                if (NPC.FindFirstNPC(ModContent.NPCType<Priest>()) >= 0 && WorldGen.genRand.Next(0, 4) == 0) { return string.Format(this.GetLocalization("Chat.SwampWitchNQ_3").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName); }
                else {
                    return WorldGen.genRand.Next(0, 3) switch {
                        0 => SwampWitchNQ_1,
                        1 => SwampWitchNQ_2,
                        _ => SwampWitchNQ_4,
                    };
                }
            }
        }
        public override void AddShops() {
            var Elessar = new Condition(string.Format(LocUtil.Loc("Condition.CompleteBabaYagaQuests"), LocUtil.Loc("QuestsSystem.Quests.Quests.Quest3Name")), () => Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 100);

            NPCShop shop = new(Type, "BabaYagaShop");

            shop.Add(ModContent.ItemType<Ushanka>());
            shop.Add(ModContent.ItemType<Valenki>());
            shop.Add(ModContent.ItemType<WallCarpet>());
            shop.Add(ModContent.ItemType<Pancakes>());

            shop.Add(ModContent.ItemType<Panacea>(), Elessar);

            shop.Register();
        }
        public override void SetChatButtons(ref string button, ref string button2) {
            string SwampWitchAnsv_1 = this.GetLocalization("Chat.SwampWitchAnsv_1").Value;
            string SwampWitchAnsv_2 = this.GetLocalization("Chat.SwampWitchAnsv_2").Value;
            string SwampWitchAnsv_3 = this.GetLocalization("Chat.SwampWitchAnsv_3").Value;
            string SwampWitchAnsv_3_2 = this.GetLocalization("Chat.SwampWitchAnsv_3_2").Value;
            string SwampWitchAnsv_4 = this.GetLocalization("Chat.SwampWitchAnsv_4").Value;
            string SwampWitchAnsv_5 = this.GetLocalization("Chat.SwampWitchAnsv_5").Value;
            string SwampWitchAnsv_6 = this.GetLocalization("Chat.SwampWitchAnsv_6").Value;
            string SwampWitchAnsv_7 = this.GetLocalization("Chat.SwampWitchAnsv_7").Value;
            string SwampWitchAnsv_8 = this.GetLocalization("Chat.SwampWitchAnsv_8").Value;
            string SwampWitchAnsv_9 = this.GetLocalization("Chat.SwampWitchAnsv_9").Value;
            string SwampWitchAnsv_10 = this.GetLocalization("Chat.SwampWitchAnsv_10").Value;
            string SwampWitch_4 = this.GetLocalization("Chat.SwampWitch_4").Value;
            string SwampWitch_6 = this.GetLocalization("Chat.SwampWitch_6").Value;
            string SwampWitch_10 = this.GetLocalization("Chat.SwampWitch_10").Value;

            Player player = Main.LocalPlayer;
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 0) { button2 = SwampWitchAnsv_1; }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 5) { button2 = SwampWitchAnsv_2; }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 20 && Main.npcChatText != SwampWitch_4) {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++) {
                    if (player.inventory[num66].type == ModContent.ItemType<BookOfSecrets>() && player.inventory[num66].stack > 0) {
                        TempNPCs.BabaYagaTempStart = true;
                        if (Main.netMode == NetmodeID.MultiplayerClient) {
                            ModPacket babaYagaTempStartIndex = Mod.GetPacket();
                            babaYagaTempStartIndex.Write((byte)6);
                            babaYagaTempStartIndex.Write(true);
                            babaYagaTempStartIndex.Send();
                        }
                        button2 = SwampWitchAnsv_3;
                        temp = true;
                    }
                }
                if (!temp) { button2 = SwampWitchAnsv_3_2; }
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 0) {
                if (!TempNPCs.BabaYagaTemp && Main.npcChatText != SwampWitch_6) { button2 = SwampWitchAnsv_4; }
                else if (TempNPCs.BabaYagaTemp && Main.npcChatText != SwampWitch_6) { button2 = SwampWitchAnsv_5; }
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 5) { button2 = SwampWitchAnsv_6; }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200) { button = SwampWitchAnsv_10; }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20) {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++) {
                    if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Main.LocalPlayer.inventory[num66].stack > 0 && Main.npcChatText != SwampWitch_10) {
                        button = SwampWitchAnsv_7;
                        button2 = SwampWitchAnsv_9;
                        temp = true;
                    }
                }
                if (!temp) {
                    button = Lang.inter[28].Value;
                    if (Main.npcChatText != SwampWitch_10) button2 = SwampWitchAnsv_8;
                }
            }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest != 200) { button = Lang.inter[28].Value; }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest >= 90) { TempNPCs.BabaYagaNewQuest = true; }
            IQuest quest = QuestRegistry.GetAvailableQuests(player, "BabaYaga").FirstOrDefault();
            if (TempNPCs.BabaYagaNewQuest && quest != null) { button2 = quest.GetButtonText(player); }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
            string SwampWitch_12 = this.GetLocalization("Chat.SwampWitch_12").Value;
            Quests quests = Main.LocalPlayer.GetModPlayer<Quests>();
            Player player = Main.LocalPlayer;
            if (firstButton) {
                if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20) {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++) {
                        if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Main.LocalPlayer.inventory[num66].stack > 0) {
                            temp = true;
                            Main.LocalPlayer.inventory[num66].stack--;
                            Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 90;
                            Main.npcChatText = SwampWitch_12;
                        }
                    }
                }
                else if (QuestVariable.ElessarQuest == 200) {
                    NPC.NewNPC(NPC.GetSource_FromThis(), BismuthWorld.WitchSpawnX, BismuthWorld.WitchSpawnY, ModContent.NPCType<EvilBabaYaga>());
                    NPC.active = false;
                }
                else { shopName = "BabaYagaShop"; }
            }
            else {
                quests.BabaYagaQuests();
                if (TempNPCs.BabaYagaNewQuest) {
                    IQuest quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.BabaYaga).FirstOrDefault();
                    quest?.OnChatButtonClicked(player);
                }
            }
        }
        public void UpdatePosition() => NPC.spriteDirection = Main.LocalPlayer.position.X >= NPC.position.X ? -1 : 1;
        public override bool CheckConditions(int left, int right, int top, int bottom) => false;
        public override void AI() {
            string SwampWitchName_1 = this.GetLocalization("Chat.SwampWitchName_1").Value;
            string SwampWitchName_2 = this.GetLocalization("Chat.SwampWitchName_2").Value;
            string SwampWitchName_3 = this.GetLocalization("Chat.SwampWitchName_3").Value;
            string SwampWitchName_4 = this.GetLocalization("Chat.SwampWitchName_4").Value;
            string SwampWitchName_5 = this.GetLocalization("Chat.SwampWitchName_5").Value;

            if (!NPC.HasGivenName) {
                NPC.GivenName = WorldGen.genRand.Next(0, 5) switch {
                    0 => SwampWitchName_1,
                    1 => SwampWitchName_2,
                    2 => SwampWitchName_3,
                    3 => SwampWitchName_4,
                    _ => SwampWitchName_5,
                };
            }
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1) {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            NPC.dontTakeDamage = true;
            if (NPC.oldVelocity.X != 0f) { NPC.velocity.X = 0f; }
            if (Main.LocalPlayer.talkNPC != -1) {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI) { UpdatePosition(); }
                if (Main.npc[Main.LocalPlayer.talkNPC].type != NPC.type) {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 10) { Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest = 0; }
                    if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 10) { Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 0; }
                }
            }
            else {
                if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 10) { Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest = 0; }
                if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 10) { Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 0; }
            }
        }
    }
}