using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.NPCs;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities {
    public class BossChecklistSupport : ModSystem {
        public override void PostSetupContent() => DoBossChecklistIntegration();
        void DoBossChecklistIntegration() {
            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod)) { return; }
            if (bossChecklistMod.Version < new Version(1, 6)) { return; }

            string internalName = "MinotaurB";
            float weight = 3.5f;
            Func<bool> downed = () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedMinotaur;
            int bossType = ModContent.NPCType<Minotaur>();
            List<int> collectibles = [ModContent.ItemType<MinotaurHorn>(), ModContent.ItemType<MinotaursWaraxe>(), ModContent.ItemType<Narsil>()];

            bossChecklistMod.Call("LogBoss", Mod, internalName, weight, downed, bossType, new Dictionary<string, object>() { ["collectibles"] = collectibles, });
            bossChecklistMod.Call("LogMiniBoss", Mod, internalName = "BansheeBoss", weight = 1.5f, downed = () => BismuthWorld.downedBanshee, bossType = ModContent.NPCType<Banshee>());
            bossChecklistMod.Call("LogBoss", Mod, internalName = "EvilBabaYagaBoss", weight = 4.5f, downed = () => BismuthWorld.downedWitch, bossType = ModContent.NPCType<EvilBabaYaga>());
            bossChecklistMod.Call("LogBoss", Mod, internalName = "EvilNecromancerBoss", weight = 4.25f, downed = () => BismuthWorld.DownedNecromancer, bossType = ModContent.NPCType<EvilNecromancer>());
            bossChecklistMod.Call("LogMiniBoss", Mod, internalName = "PapuanWizardBoss", weight = 7.5f, downed = () => BismuthWorld.DownedPapuanWizard, bossType = ModContent.NPCType<PapuanWizard>());
            bossChecklistMod.Call("LogMiniBoss", Mod, internalName = "RhinoOrcBoss", weight = 5.5f, downed = () => BismuthWorld.DownedRhino, bossType = ModContent.NPCType<RhinoOrc>());
        }
    }
}