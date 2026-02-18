using Bismuth.Content.NPCs;
using Bismuth.Content.Tiles;
using Bismuth.Content.Walls;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Bismuth.Utilities {
    public class BismuthGen {
        public static void GenCrypt(IEntitySource source, int CryptX, int CryptY) {
            for (int i = 0; i < 15; i++) {
                WorldMethods.BresenhamLineTunnel(CryptX - 5 + Main.rand.Next(-5 + i, 5 + i), CryptY + 12 - i, CryptX + 15 + Main.rand.Next(-5 + i, 5 + i), CryptY + 12 - i, 4);
            }
            for (int i = 0; i < 50; i++) {
                for (int j = 0; j < 50; j++) {
                    Main.tile[CryptX - 15 + j, CryptY + 15 - i].LiquidAmount = 0;
                }
            }
            int[,] Crypt = new int[,]
            {
                       {0, 0, 0, 0, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 1, 6, 4, 4, 4, 4, 4, 5, 1, 0, 0, 0, 0, 0},
                       {0, 3, 1, 1, 1, 1, 4, 7, 0, 0, 0, 8, 4, 1, 1, 1, 1, 2, 0},
                       {0, 1, 6, 4, 4, 4, 4, 0, 0, 0, 0, 0, 4, 4, 4, 4, 5, 1, 0},
                       {0, 1, 4, 7, 0, 8, 4, 0, 0, 0, 0, 0, 4, 7, 0, 8, 4, 1, 0},
                       {3, 1, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 1, 2},
                       {1, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 1},
                       {1, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 8, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };
            for (int j = 0; j < Crypt.GetLength(0); j++) {
                for (int i = 0; i < Crypt.GetLength(1); i++) {
                    switch (Crypt[j, i]) {
                        case 0:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        break;
                        case 1:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                        break;
                        case 2:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 1);
                        break;
                        case 3:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 2);
                        break;
                        case 4:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                        break;
                        case 5:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 1);
                        break;
                        case 6:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 2);
                        break;
                        case 7:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 3);
                        break;
                        case 8:
                        WorldGen.KillTile(CryptX + i, CryptY + j);
                        WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                        WorldGen.SlopeTile(CryptX + i, CryptY + j, 4);
                        break;
                    }
                }
            }
            int[,] CryptWall = new int[,]
            {
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 3, 1, 1, 1, 2, 2, 3, 0, 0, 0, 0, 0, 0},
                       {0, 0, 1, 0, 0, 0, 3, 1, 1, 1, 2, 2, 3, 0, 0, 0, 1, 0, 0},
                       {0, 0, 3, 2, 2, 1, 3, 1, 2, 1, 1, 2, 3, 2, 2, 1, 3, 0, 0},
                       {0, 0, 3, 2, 2, 1, 3, 2, 2, 1, 1, 1, 3, 2, 2, 1, 3, 0, 0},
                       {0, 1, 3, 2, 2, 1, 3, 2, 2, 1, 1, 1, 3, 2, 1, 1, 3, 1, 0},
                       {0, 1, 3, 2, 1, 1, 3, 2, 1, 1, 1, 1, 3, 2, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 2, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 2, 2, 3, 1, 0},
                       {0, 2, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 2, 1, 3, 1, 0},
                       {0, 2, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
            for (int j = 0; j < CryptWall.GetLength(0); j++) {
                for (int i = 0; i < CryptWall.GetLength(1); i++) {
                    switch (CryptWall[j, i]) {
                        case 0:
                        break;
                        case 1:
                        WorldGen.KillWall(CryptX + i, CryptY + j);
                        WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.Ebonwood);
                        break;
                        case 2:
                        WorldGen.KillWall(CryptX + i, CryptY + j);
                        WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.Bone);
                        WorldGen.paintWall(CryptX + i, CryptY + j, 27);
                        break;
                        case 3:
                        WorldGen.KillWall(CryptX + i, CryptY + j);
                        WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.PearlstoneBrick);
                        break;
                    }
                }
            }
            WorldGen.PlaceTile(CryptX + 1, CryptY + 10, TileID.Platforms, false, false, -1, 16);
            WorldGen.PlaceTile(CryptX + 1, CryptY + 9, TileID.Books);
            WorldGen.PlaceTile(CryptX + 17, CryptY + 10, TileID.Platforms, false, false, -1, 16);
            WorldGen.PlaceTile(CryptX + 17, CryptY + 9, TileID.Books);
            WorldGen.PlaceTile(CryptX + 1, CryptY + 13, ModContent.TileType<Bone1>());
            WorldGen.PlaceTile(CryptX + 17, CryptY + 13, ModContent.TileType<Bone1>());
            WorldGen.Place3x1(CryptX + 10, CryptY + 13, (ushort)ModContent.TileType<Bone4>());
            WorldGen.Place3x2(CryptX + 3, CryptY + 13, TileID.Campfire, 2);
            WorldGen.Place3x2(CryptX + 15, CryptY + 13, TileID.Campfire, 2);
            WorldGen.Place2x2(CryptX + 13, CryptY + 13, TileID.CookingPots, 0);
            WorldGen.PlaceTile(CryptX + 9, CryptY + 2, TileID.Chandeliers, false, false, -1, 32);
            NPC.NewNPC(source, (CryptX + 11) * 16, (CryptY + 10) * 16, ModContent.NPCType<Necromant>());
        }
        public static void GenCityNPC(IEntitySource source, int x, int y) {
            if (!NPC.AnyNPCs(ModContent.NPCType<ImperianConsul>())) {
                NPC.NewNPC(source, (x + 6) * 16 + 4, (y + 3) * 16, ModContent.NPCType<ImperianConsul>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<DwarfBlacksmith>())) {
                NPC.NewNPC(source, (x - 24) * 16, (y + 3) * 16, ModContent.NPCType<DwarfBlacksmith>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Beggar>())) {
                NPC.NewNPC(source, (x - 43) * 16, (y + 3) * 16, ModContent.NPCType<Beggar>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && QuestVariable.PotionQuest != 200) {
                NPC.NewNPC(source, (x - 61) * 16, (y + 4) * 16, ModContent.NPCType<Alchemist>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<ImperianCommander>())) {
                NPC.NewNPC(source, (x + 59) * 16, (y + 4) * 16, ModContent.NPCType<ImperianCommander>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<StrangeOldman>()) && Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest >= 40 && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest != 100 && QuestVariable.NewPriestQuest != 100) {
                NPC.NewNPC(source, (x + 45) * 16, (y - 10) * 16, ModContent.NPCType<StrangeOldman>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<OldmanPriest>()) && QuestVariable.NewPriestQuest == 100) {
                NPC.NewNPC(source, (x + 29) * 16, (y + 2) * 16 - 2, ModContent.NPCType<OldmanPriest>());
            }
        }
        public static void GenMaze() {
            if (NPC.downedBoss1) {
                BismuthWorld.MazeStartX = WorldGen.genRand.Next(Main.spawnTileX - 150, Main.spawnTileX + 100);
                BismuthWorld.MazeStartY = Main.maxTilesY / 2;
                BismuthWorld.downedEoC = true;
                if (Main.netMode == NetmodeID.Server) {
                    NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                int[,] Maze = new int[,]
                     { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2  },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 1, 0, 0, 1, 0, 3, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 1, 1, 1, 0, 3, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 1, 1, 3, 0, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 3, 1, 1, 0, 0, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 3, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 1, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 0, 0, 0, 0, 0, 1, 3, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 3, 1, 0, 3, 1, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 0, 3, 1, 1, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 1, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 3, 0, 0, 1, 0, 0, 3, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 0, 1, 1, 1, 1, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 3, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 0, 3, 0, 1, 1, 1, 1, 1, 3, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 3, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 3, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, }, };


                for (int j = 0; j < Maze.GetLength(0); j++) {
                    for (int i = 0; i < Maze.GetLength(1); i++) {
                        switch (Maze[j, i]) {
                            case 0:
                            WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                            Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                            break;
                            case 1:
                            WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                            WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                            Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                            break;
                            case 2:
                            WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                            Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                            break;
                            case 3:
                            WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                            WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, TileID.Chain);
                            Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                            break;
                            case 4:
                            WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                            WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                            Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                            // WorldGen.Place2x1(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)mod.TileType("Ladder"));

                            WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                            break;
                        }
                        WorldGen.Place1xX(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 3, (ushort)ModContent.TileType<GreenDoorLocked>());
                        WorldGen.Place1xX(BismuthWorld.MazeStartX + 30, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<BlueDoorLocked>());
                        WorldGen.Place1xX(BismuthWorld.MazeStartX + 41, BismuthWorld.MazeStartY + 51, (ushort)ModContent.TileType<RedDoorLocked>());
                    }
                }
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 5, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 26, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 42, BismuthWorld.MazeStartY + 6, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 3, BismuthWorld.MazeStartY + 7, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 8, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 44, BismuthWorld.MazeStartY + 10, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 11, BismuthWorld.MazeStartY + 11, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 11, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 12, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 37, BismuthWorld.MazeStartY + 19, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 20, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 43, BismuthWorld.MazeStartY + 23, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 13, BismuthWorld.MazeStartY + 24, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 27, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 28, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 32, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 31, BismuthWorld.MazeStartY + 32, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 36, BismuthWorld.MazeStartY + 36, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 14, BismuthWorld.MazeStartY + 40, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 17, BismuthWorld.MazeStartY + 44, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 27, BismuthWorld.MazeStartY + 44, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 36, BismuthWorld.MazeStartY + 51, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 16, BismuthWorld.MazeStartY + 52, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 56, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 35, BismuthWorld.MazeStartY + 56, ModContent.TileType<Bone1>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 26, BismuthWorld.MazeStartY + 8, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 4, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 18, BismuthWorld.MazeStartY + 20, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 50, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 51, BismuthWorld.MazeStartY + 31, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 36, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 52, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 12, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place2x1(BismuthWorld.MazeStartX + 48, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone2>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 40, BismuthWorld.MazeStartY + 2, (ushort)ModContent.TileType<Bone3>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 11, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<Bone3>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 20, (ushort)ModContent.TileType<Bone3>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 45, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<Bone3>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 45, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone3>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 3, (ushort)ModContent.TileType<Bone4>());
                WorldGen.Place3x1(BismuthWorld.MazeStartX + 34, BismuthWorld.MazeStartY + 40, (ushort)ModContent.TileType<Bone4>());
                WorldGen.Place2x2(BismuthWorld.MazeStartX + 38, BismuthWorld.MazeStartY + 11, (ushort)ModContent.TileType<amphora3>(), 0);
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 4, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<amphora1>());
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 56, BismuthWorld.MazeStartY + 7, (ushort)ModContent.TileType<amphora2>());
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 41, BismuthWorld.MazeStartY + 19, (ushort)ModContent.TileType<amphora2>());
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 29, BismuthWorld.MazeStartY + 44, (ushort)ModContent.TileType<amphora2>());
                WorldGen.Place2x2(BismuthWorld.MazeStartX + 22, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<amphora3>(), 0);
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 22, BismuthWorld.MazeStartY + 32, (ushort)ModContent.TileType<amphora2>());
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 36, (ushort)ModContent.TileType<amphora1>());
                WorldGen.Place2x2(BismuthWorld.MazeStartX + 38, BismuthWorld.MazeStartY + 32, (ushort)ModContent.TileType<amphora3>(), 0);
                WorldGen.Place2xX(BismuthWorld.MazeStartX + 48, BismuthWorld.MazeStartY + 34, (ushort)ModContent.TileType<amphora1>());
                WorldGen.Place2x2(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 48, (ushort)ModContent.TileType<amphora3>(), 0);
                WorldGen.Place2x2(BismuthWorld.MazeStartX + 28, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<amphora3>(), 0);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY - 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY - 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY - 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY - 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY - 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY - 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY - 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 1);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 2);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 3);
                WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 4);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 1, BismuthWorld.MazeStartY - 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 1, BismuthWorld.MazeStartY + 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY - 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 2, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 3, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 2, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 2, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 3, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 4, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 1, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 2, TileID.Stone);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 1, TileID.Stone);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (BismuthWorld.MazeStartX + 4) * 16, (BismuthWorld.MazeStartY + 3) * 16 - 4, ModContent.NPCType<StrangeOldman>());
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 2, TileID.Torches);
                WorldGen.PlaceTile(BismuthWorld.MazeStartX + 43, BismuthWorld.MazeStartY + 2, ModContent.TileType<Content.Tiles.Luceat>());
                int greenchest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<GreenMazeChest>(), false, 0);
                int greenchestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 22);
                if (greenchestIndex != -1) {
                    BismuthGenLoot.GenerateBiomeGreenChestLoot(Main.chest[greenchestIndex].item, 0);
                }

                int bluechest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<BlueMazeChest>(), false, 0);
                int bluechestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 15);
                if (bluechestIndex != -1) {
                    BismuthGenLoot.GenerateBiomeBlueChestLoot(Main.chest[bluechestIndex].item, 0);
                }

                int redchest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<RedMazeChest>(), false, 0);
                int redchestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 55);
                if (redchestIndex != -1) {
                    BismuthGenLoot.GenerateBiomeRedChestLoot(Main.chest[redchestIndex].item, 0);
                }
                if (Main.netMode == NetmodeID.Server) { NetMessage.SendTileSquare(-1, BismuthWorld.MazeStartX, BismuthWorld.MazeStartY, 240); }
            }
        }
        public static void GenSunrise(int x, int y) {
            WorldGen.PlaceTile(x, y, ModContent.TileType<SunrisePicture>());
            if (Main.netMode != NetmodeID.MultiplayerClient) { NetMessage.SendTileSquare(-1, x, y, 10); }
        }
        public static void EditWaterTempe(bool downed, int x, int y) {
            if (!downed) {
                Main.tile[x + 9, y + 17].TileFrameX = 72;
                Main.tile[x + 40, y + 17].TileFrameX = 72;
                Main.tile[x + 19, y + 14].TileFrameX = 54;
                Main.tile[x + 19, y + 13].TileFrameX = 54;
                Main.tile[x + 18, y + 14].TileFrameX = 36;
                Main.tile[x + 18, y + 13].TileFrameX = 36;
                Main.tile[x + 32, y + 14].TileFrameX = 54;
                Main.tile[x + 32, y + 13].TileFrameX = 54;
                Main.tile[x + 31, y + 14].TileFrameX = 36;
                Main.tile[x + 31, y + 13].TileFrameX = 36;
            }
            else {
                Main.tile[x + 9, y + 17].TileFrameX = 0;
                Main.tile[x + 40, y + 17].TileFrameX = 0;
                Main.tile[x + 19, y + 14].TileFrameX = 18;
                Main.tile[x + 19, y + 13].TileFrameX = 18;
                Main.tile[x + 18, y + 14].TileFrameX = 0;
                Main.tile[x + 18, y + 13].TileFrameX = 0;
                Main.tile[x + 32, y + 14].TileFrameX = 18;
                Main.tile[x + 32, y + 13].TileFrameX = 18;
                Main.tile[x + 31, y + 14].TileFrameX = 0;
                Main.tile[x + 31, y + 13].TileFrameX = 0;
            }
        }
        public static void GenOre(List<GenPass> tasks, int index, string name) {
            tasks.Insert(index + 1, new PassLegacy(name, delegate (GenerationProgress progress, GameConfiguration configuration) {
                progress.Message = "Generating more vanilla ores";
                #region Mod Ores
                int aluminium = ModContent.TileType<AluminiumOre>();
                int cinnabar = ModContent.TileType<Cinnabar>();
                for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++) {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), aluminium, false, 0f, 0f, false, true);
                }
                for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++) {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), aluminium, false, 0f, 0f, false, true);
                }
                for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++) {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), aluminium, false, 0f, 0f, false, true);
                }
                for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05 / 2); num++) {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), cinnabar, false, 0f, 0f, false, true);
                }
                for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++) {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), cinnabar, false, 0f, 0f, false, true);
                }
                #endregion
                #region More Vanilla Ores
                bool CopperInWorld, TinInWorld, IronInWorld, LeadInWorld, SilverInWorld, TungstenInWorld, GoldInWorld, PlatinumInWorld = CopperInWorld = TinInWorld = IronInWorld = LeadInWorld = SilverInWorld = TungstenInWorld = GoldInWorld = false;
                for (int x = 0; x < Main.maxTilesX; x++) {
                    for (int y = 0; y < Main.maxTilesY; y++) {
                        if (Main.tile[x, y].TileType == TileID.Copper) { CopperInWorld = true; }
                        else { TinInWorld = true; }
                        if (Main.tile[x, y].TileType == TileID.Iron) { IronInWorld = true; }
                        else { LeadInWorld = true; }
                        if (Main.tile[x, y].TileType == TileID.Silver) { SilverInWorld = true; }
                        else { TungstenInWorld = true; }
                        if (Main.tile[x, y].TileType == TileID.Gold) { GoldInWorld = true; }
                        else { PlatinumInWorld = true; }
                        if (x == Main.maxTilesX && y == Main.maxTilesY) { break; }
                    }
                }
                if (CopperInWorld) {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); n++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.Tin, false, 0f, 0f, false, true);
                    }
                    for (int l = 0; l < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); l++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileID.Tin, false, 0f, 0f, false, true);
                    }
                    for (int m = 0; m < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); m++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tin, false, 0f, 0f, false, true);
                    }
                }
                if (TinInWorld) {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); n++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.Copper, false, 0f, 0f, false, true);
                    }
                    for (int l = 0; l < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); l++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileID.Copper, false, 0f, 0f, false, true);
                    }
                    for (int m = 0; m < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); m++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Copper, false, 0f, 0f, false, true);
                    }
                }
                if (IronInWorld) {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), TileID.Lead, false, 0f, 0f, false, true);
                    }
                    for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Lead, false, 0f, 0f, false, true);
                    }
                    for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Lead, false, 0f, 0f, false, true);
                    }
                }
                if (LeadInWorld) {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), TileID.Iron, false, 0f, 0f, false, true);
                    }
                    for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Iron, false, 0f, 0f, false, true);
                    }
                    for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Iron, false, 0f, 0f, false, true);
                    }
                }
                if (SilverInWorld) {
                    for (int num3 = 0; num3 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num3++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                    for (int num4 = 0; num4 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num4++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                    for (int num5 = 0; num5 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num5++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                }
                if (TungstenInWorld) {
                    for (int num3 = 0; num3 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num3++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Silver, false, 0f, 0f, false, true);
                    }
                    for (int num4 = 0; num4 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num4++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Silver, false, 0f, 0f, false, true);
                    }
                    for (int num5 = 0; num5 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num5++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Silver, false, 0f, 0f, false, true);
                    }
                }
                if (GoldInWorld) {
                    for (int num6 = 0; num6 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num6++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Platinum, false, 0f, 0f, false, true);
                    }
                    for (int num7 = 0; num7 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num7++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow - 20), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Platinum, false, 0f, 0f, false, true);
                    }
                }
                if (PlatinumInWorld) {
                    for (int num6 = 0; num6 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num6++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Gold, false, 0f, 0f, false, true);
                    }
                    for (int num7 = 0; num7 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num7++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow - 20), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Gold, false, 0f, 0f, false, true);
                    }
                }
                #endregion
            }));
        }
    }
}