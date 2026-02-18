using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs {
    [AutoloadHead]
    public class TravelingVampire : ModNPC {
        public override void SetStaticDefaults() {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load() {
            _ = this.GetLocalization("Chat.TravelingVampireNQ_1").Value; // Ru: Не объяснишь ли ты, почему черепаха живет дольше, нежели целые поколения людей; почему слон переживает целые династии и почему попугай умирает лишь от укуса кошки или собаки, а не от других недугов?
                                                                         // En: Can you tell me why the tortoise lives more long than generations of men, why the elephant goes on and on till he have sees dynasties, and why the parrot never die only of bite of cat of dog or other complaint?
            _ = this.GetLocalization("Chat.TravelingVampireNQ_2").Value; // Ru: Кто сказал тебе, что обязательно становится Стражем Болота? En: Who told you that he must become a guard of the swamp?
            _ = this.GetLocalization("Chat.TravelingVampireNQ_3").Value; // Ru: Carpe Jugulum! En: Carpe Jugulum!
            _ = this.GetLocalization("Chat.TravelingVampireNQ_4").Value; // Ru: Ненавижу сумерки. En: I hate Twillight.
            _ = this.GetLocalization("Chat.TravelingVampireNQ_5").Value; // Ru: Людской век краток, вампиры же вечны. En: The time of people’s life is much too short, vampires are eternal.
            _ = this.GetLocalization("Chat.TravelingVampireNQ_6").Value; // Ru: Маскарад поможет тебе остаться незамеченным. En: The Masquerade will help you to disguise.
            _ = this.GetLocalization("Chat.NoBloodMoon").Value; // Ru: Похоже, сейчас не время для этого. En: It seems that now is not the time for this.
        }
        public override List<string> SetNPCNameList() =>
        [
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_3");
            this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_4");
            this.GetLocalizedValue("Name.Robert"), // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_5");
            this.GetLocalizedValue("Name.Vlad") // Language.GetTextValue("Mods.Bismuth.TravelingVampireName_6");
        ];
        public override bool CheckConditions(int left, int right, int top, int bottom) => false;
        public override string GetChat() {
            string TravelingVampireNQ_1 = this.GetLocalization("Chat.TravelingVampireNQ_1").Value;
            string TravelingVampireNQ_2 = this.GetLocalization("Chat.TravelingVampireNQ_2").Value;
            string TravelingVampireNQ_3 = this.GetLocalization("Chat.TravelingVampireNQ_3").Value;
            string TravelingVampireNQ_4 = this.GetLocalization("Chat.TravelingVampireNQ_4").Value;
            string TravelingVampireNQ_5 = this.GetLocalization("Chat.TravelingVampireNQ_5").Value;
            string TravelingVampireNQ_6 = this.GetLocalization("Chat.TravelingVampireNQ_6").Value;

            return WorldGen.genRand.Next(0, 6) switch {
                0 => TravelingVampireNQ_1,
                1 => TravelingVampireNQ_2,
                2 => TravelingVampireNQ_3,
                3 => TravelingVampireNQ_4,
                4 => TravelingVampireNQ_5,
                _ => TravelingVampireNQ_6,
            };
        }
        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 26;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 700;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override void SetChatButtons(ref string button, ref string button2) {
            button = Lang.inter[28].Value;
        }
        public override void ModifyActiveShop(string shopName, Item[] items) {
            shopName = "VampirShop";
            if (shopName == "VampirShop") {
                if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().IsVampire) {
                    items[0] = new Item(BismuthWorld.VampShop[0]);
                    items[1] = new Item(BismuthWorld.VampShop[1]);
                    items[2] = new Item(BismuthWorld.VampShop[2]);
                }
                else {
                    items[0] = new Item(ModContent.ItemType<Sanguinem>());
                }
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
            if (firstButton) {
                if (!Main.bloodMoon) { Main.npcChatText = "not time for this"; }
                else {
                    if (BismuthWorld.VampShop[0] == 0) { BismuthWorld.setVampShop(); }
                    shopName = "VampirShop"; 
                }
            }
        }
        public void UpdatePosition() => NPC.spriteDirection = Main.LocalPlayer.position.X >= NPC.position.X ? -1 : 1;
        public override void AI() {
            if (Main.LocalPlayer.talkNPC >= 0) {
                NPC npC = Main.npc[Main.LocalPlayer.talkNPC];
                if (npC.type == NPC.type) { UpdatePosition(); }
            }
            if (Main.dayTime) {
                NPC.active = false;
                BismuthWorld.VampShop = [0, 0, 0];
            }
        }
    }
}