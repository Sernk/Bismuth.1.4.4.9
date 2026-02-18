using Bismuth.Content.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Bismuth.Utilities.BismuthWorld;

namespace Bismuth.Utilities {
    public class DesertVillage : BaseWorldGens {
        // 0 empty, 1 sand, 2 hardened sand
        static bool DesertPitGen = false;
        public static int DesertPitX = 0;
        public static int DesertPitY = 0;

        static readonly byte[,] DesertVillageTiles = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 1
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 2
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 3
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,0,0,0,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1}, // 4
            {1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,0,0,0,0,0,0,0,0,0,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1}, // 5
            {1,1,1,1,1,1,1,1,1,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,1,1,1,1,1,1,1,1,1,1}, // 6
            {1,1,1,1,1,1,1,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,1,1,1,1,1,1,1,1,1}, // 7
            {1,1,1,1,1,1,1,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1,1}, // 8
            {1,1,1,1,1,1,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,1,1,1,1,1,1,1,1}, // 9
            {1,1,1,1,1,1,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1}, // 10
            {1,1,1,1,1,1,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1}, // 11
            {1,1,1,1,1,1,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,1,1,1,1,1,1}, // 12
            {1,1,1,1,1,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,1,1,1,1,1,1,1}, // 13
            {1,1,1,1,1,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,1,1,1,1,1,1,1}, // 14
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1}, // 15
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1}, // 16
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1}, // 17
            {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 18
            {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 19
            {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 20
            {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 21
            {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 22
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1}, // 23
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 24
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 25
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 26
            {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 27
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 28
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1}, // 29
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1}, // 30
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1}, // 31
            {1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1}, // 32
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 33
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 34
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 35
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 36
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 37
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 38
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 39
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1}, // 40
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1}, // 41
            {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1}, // 42
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1}, // 43
        };
        // 0 - empty / 1 - hamer / 2 - /| / 3 - |/ / 4 - \| / 5 - |\
        static readonly byte[,] DesertVillageSlope = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 1
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 2
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 3
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 4
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 5
            {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 6
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0}, // 7
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 8
            {0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 9
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 10
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 11
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 12
            {0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 13
            {0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 14
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 15
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0}, // 16
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0}, // 17
            {0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 18
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 19
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 20
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 21
            {0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 22
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0}, // 23
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 24
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 25
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 26
            {0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 27
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0}, // 28
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 29
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 30
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 31
            {0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0}, // 32
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 33
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 34
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 35
            {0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 36
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 37
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 38
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 39
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 40
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 41
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 42
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 43
        };
        static readonly byte[,] DesertVillageWalls = {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 1
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 2
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 3
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 4
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 5
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 6
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 7
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 8
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 9
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 10
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 11
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 12
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 13
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 14
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 15
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 16
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 17
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 18
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 19
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 20
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 21
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 22
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 23
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 24
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 25
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 26
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 27
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 28
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 29
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 30
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 31
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 32
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 33
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 34
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, // 35
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 36
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 37
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 38
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 39
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 40
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 41
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 42
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, // 43
        };
        public override bool GensBool { get => DesertPitGen; set => DesertPitGen = value; }
        public override string NameGen => "[Bismuth] Desert Village";
        public override string VanillaIndexName => "Remove Broken Traps";
        public static void Cleaning(int startX, int startY, int endX, int endY, params int[] type) {
            int minX = Math.Min(startX, endX);
            int maxX = Math.Max(startX, endX);
            int minY = Math.Min(startY, endY);
            int maxY = Math.Max(startY, endY);

            HashSet<int> tileTypesToDestroy = [.. type];

            for (int x = minX; x <= maxX; x++) {
                for (int y = minY; y <= maxY; y++) {
                    if (WorldGen.InWorld(x, y, 10) && Main.tile[x, y].HasTile && tileTypesToDestroy.Contains(Main.tile[x, y].TileType)) {
                        Tile tile = Main.tile[x, y];
                        tile.WallType = WallID.None;
                        tile.HasTile = false;
                    }
                }
            }
        }

        public override bool Do_MakeGen(GenerationProgress progress) {
            if (progress != null) {
                progress.Message = "";
                progress.Set(0.99f);
            }

            // Desert Setup
            Rectangle desert = GenVars.UndergroundDesertLocation;
            int desertLeft = desert.Left;
            int desertRight = desert.Right;
            int desertTop = desert.Top;
            int centerX = (desertLeft + desertRight) / 2;

            // Cleaning
            int startX = centerX - 19;
            int startY = desertTop + 54;

            int EndX = centerX + 18;
            int EndY = desertTop;

            DesertPitX = EndX;
            DesertPitY = startY;

            int width = DesertVillageTiles.GetLength(1);
            int height = DesertVillageTiles.GetLength(0);

            Cleaning(EndX, startY, startX, EndY, TileID.Sand, 396, 397);

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    int worldX = startX + x;
                    int worldY = startY - y;

                    if (!WorldGen.InWorld(worldX, worldY, 10)) {
                        continue;
                    }

                    Tile tile = Framing.GetTileSafely(worldX, worldY);
                    tile.ClearEverything();

                    switch (DesertVillageTiles[y, x]) {
                        case 0: break;
                        case 1: tile.TileType = TileID.Sand; tile.HasTile = true; break;
                        case 2: tile.TileType = TileID.HardenedSand; tile.HasTile = true; break;
                    }
                    switch (DesertVillageSlope[y, x]) {
                        case 0: break;
                        case 1: tile.IsHalfBlock = true; break;
                        case 2: tile.Slope = SlopeType.SlopeDownRight; break;
                        case 3: tile.Slope = SlopeType.SlopeUpLeft; break;
                        case 4: tile.Slope = SlopeType.SlopeUpRight; break;
                        case 5: tile.Slope = SlopeType.SlopeDownLeft; break;
                    }
                    switch (DesertVillageWalls[y, x]) {
                        case 0: break;
                        case 1: tile.WallType = WallID.Sandstone; break;
                    }
                }
            }
            int left = Math.Max(0, desert.Left - 50);
            int right = Math.Min(Main.maxTilesX - 1, desert.Right + 50);
            int top = Math.Max((int)GenVars.worldSurfaceLow, desert.Top - 20);
            int bottom = Math.Min(Main.maxTilesY - 1, desert.Bottom + 50);

            StartDesertVillageX = -1;
            StartDesertVillageY = -1;
            DesertVillageLeftBorderX = -1;
            DesertVillageLeftBorderY = -1;
            DesertVillageRightBorderX = -1;
            DesertVillageRightBorderY = -1;

            for (int i = left; i <= right; i++) {
                for (int j = top; j <= bottom; j++) {
                    if (!WorldGen.TileEmpty(i, j))
                        break;
                    if (WorldMethods.CheckWall(i, j, WallID.HardenedSand) || WorldMethods.CheckWall(i, j, WallID.Sandstone)) {
                        StartDesertVillageX = i;
                        StartDesertVillageY = j;
                        goto LeftBorder;
                    }
                }
            }
        LeftBorder:
            for (int i = left; i <= right; i++) {
                for (int j = top; j <= bottom; j++) {
                    if (WorldMethods.CheckWall(i, j, WallID.HardenedSand) || WorldMethods.CheckWall(i, j, WallID.Sandstone)) {
                        DesertVillageLeftBorderX = i;
                        DesertVillageLeftBorderY = j;
                        goto RightBorder;
                    }
                }
            }
        RightBorder:
            for (int i = right; i >= left; i--) {
                for (int j = top; j <= bottom; j++) {
                    if (WorldMethods.CheckWall(i, j, WallID.HardenedSand) || WorldMethods.CheckWall(i, j, WallID.Sandstone)) {
                        DesertVillageRightBorderX = i;
                        DesertVillageRightBorderY = j;
                        goto Calculate;
                    }
                }
            }
        Calculate:
            TempY = StartDesertVillageY;
            while (WorldMethods.CheckWall(StartDesertVillageX, StartDesertVillageY, WallID.Sandstone) || WorldMethods.CheckWall(StartDesertVillageX, StartDesertVillageY, WallID.HardenedSand)) {
                StartDesertVillageY--;
                if (StartDesertVillageY < top) { break; }
            }
            while (!WorldMethods.CheckTile(StartDesertVillageX, StartDesertVillageY, TileID.Sand)) {
                StartDesertVillageX--;
                if (StartDesertVillageX < left) { break; }
            }
            StartBridgeX = StartDesertVillageX;
            BridgeY = StartDesertVillageY;
            EndBridgeX = StartBridgeX + 2;
            while (EndBridgeX < right && EndBridgeX >= 0 && EndBridgeX < Main.maxTilesX && BridgeY >= 0 && BridgeY < Main.maxTilesY && WorldGen.TileEmpty(EndBridgeX, BridgeY)) { EndBridgeX++; }
            EndBridgeX = Math.Min(EndBridgeX, Main.maxTilesX - 1);
            EndBridgeX--;
            IsDesertSuccess = true;
            if (Main.maxTilesX > 8400) {
                if (EndBridgeX - StartBridgeX > 100) { IsDesertSuccess = false; }
            }
            else {
                if (EndBridgeX - StartBridgeX > 50) { IsDesertSuccess = false; }
            }
            if (IsDesertSuccess) {
                #region Searching
                for (int i = DesertVillageLeftBorderX; i < StartBridgeX; i++) {
                    for (int j = BridgeY - 10; j < TempY; j++) {
                        if ((WorldMethods.CheckWall(i, j, WallID.Sandstone) || WorldMethods.CheckWall(i, j + 1, WallID.Sandstone)) && WorldGen.TileEmpty(i, j)) { WorldGen.PlaceTile(i, j, TileID.Sand); }
                        WorldGen.SlopeTile(i + 1, j, 0);
                        WorldGen.SlopeTile(i - 1, j, 0);
                        WorldGen.SlopeTile(i, j + 1, 0);
                        WorldGen.SlopeTile(i, j - 1, 0);
                    }
                }
                for (int i = EndBridgeX; i < DesertVillageRightBorderX; i++) {
                    for (int j = BridgeY - 10; j < TempY; j++) {
                        if ((WorldMethods.CheckWall(i, j, WallID.Sandstone) || WorldMethods.CheckWall(i, j + 1, WallID.Sandstone)) && WorldGen.TileEmpty(i, j)) { WorldGen.PlaceTile(i, j, TileID.Sand); }
                        WorldGen.SlopeTile(i + 1, j, 0);
                        WorldGen.SlopeTile(i - 1, j, 0);
                        WorldGen.SlopeTile(i, j + 1, 0);
                        WorldGen.SlopeTile(i, j - 1, 0);
                    }
                }
                for (int i = 0; i < EndBridgeX - StartBridgeX + 4; i++) {
                    for (int j = 0; j < 16; j++) { WorldGen.KillWall(StartBridgeX - 2 + i, BridgeY - 8 + j); }
                }
                #endregion
                #region Bridge
                for (int i = 0; i < 2; i++) { WorldGen.PlaceTile(StartBridgeX + i, BridgeY, ModContent.TileType<PapuansPlatform>()); }
                WorldGen.SlopeTile(StartBridgeX + 1, BridgeY, 1);
                for (int i = 0; i < 2; i++) { WorldGen.PlaceTile(EndBridgeX - i, BridgeY, ModContent.TileType<PapuansPlatform>()); }

                WorldGen.SlopeTile(EndBridgeX - 1, BridgeY, 2);
                for (int i = 0; i < 3; i++) { WorldGen.PlaceTile(StartBridgeX + 1 + i, BridgeY + 1, ModContent.TileType<PapuansPlatform>()); }
                WorldGen.SlopeTile(StartBridgeX + 3, BridgeY + 1, 1);
                for (int i = 0; i < 3; i++) { WorldGen.PlaceTile(EndBridgeX - 1 - i, BridgeY + 1, ModContent.TileType<PapuansPlatform>()); }
                WorldGen.SlopeTile(EndBridgeX - 3, BridgeY + 1, 2);
                for (int i = 0; i < (EndBridgeX - (StartBridgeX + 5)); i++) { WorldGen.PlaceTile(StartBridgeX + 3 + i, BridgeY + 2, ModContent.TileType<PapuansPlatform>()); }
                for (int i = 0; i < 15; i++) {
                    WorldGen.KillWall(StartBridgeX - 1, BridgeY + 8 - i);
                    WorldGen.PlaceWall(StartBridgeX - 1, BridgeY + 8 - i, WallID.PalmWoodFence);
                }
                WorldGen.PlaceTile(StartBridgeX - 1, BridgeY - 6, ModContent.TileType<PapuansPlatform>());
                WorldGen.PlaceWall(StartBridgeX, BridgeY - 6, WallID.PalmWoodFence);
                for (int i = 0; i < 15; i++) {
                    WorldGen.KillWall(EndBridgeX + 1, BridgeY + 8 - i);
                    WorldGen.PlaceWall(EndBridgeX + 1, BridgeY + 8 - i, WallID.PalmWoodFence);
                }
                WorldGen.PlaceTile(EndBridgeX + 1, BridgeY - 6, ModContent.TileType<PapuansPlatform>());
                WorldGen.PlaceWall(EndBridgeX, BridgeY - 6, WallID.PalmWoodFence);

                for (int i = 0; i <= EndBridgeX - StartBridgeX; i++) {
                    for (int j = 0; j < 4; j++) {
                        if (Main.tile[StartBridgeX + i, BridgeY + j].TileType == ModContent.TileType<PapuansPlatform>()) {
                            if ((StartBridgeX + i) % 2 == 1) {
                                WorldGen.PlaceWall(StartBridgeX + i, BridgeY + j, WallID.PearlwoodFence);
                                WorldGen.PlaceWall(StartBridgeX + i, BridgeY + j - 1, WallID.PearlwoodFence);
                            }
                            else { WorldGen.PlaceWall(StartBridgeX + i, BridgeY + j, WallID.PalmWoodFence); }
                        }
                    }
                }
                WorldGen.PlaceTile(StartBridgeX, BridgeY - 6, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX, BridgeY - 5, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 1, BridgeY - 5, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 1, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 1, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 1, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 1, BridgeY - 1, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 2, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 2, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 3, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 3, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 3, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 3, BridgeY - 1, TileID.Rope);
                WorldGen.PlaceTile(StartBridgeX + 3, BridgeY, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX, BridgeY - 6, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX, BridgeY - 5, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 1, BridgeY - 5, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 1, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 1, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 1, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 1, BridgeY - 1, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 2, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 2, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 3, BridgeY - 4, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 3, BridgeY - 3, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 3, BridgeY - 2, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 3, BridgeY - 1, TileID.Rope);
                WorldGen.PlaceTile(EndBridgeX - 3, BridgeY, TileID.Rope);
                for (int i = 0; i < (EndBridgeX - (StartBridgeX + 5)); i++) {
                    WorldGen.PlaceTile(StartBridgeX + 3 + i, BridgeY - 3, TileID.Rope);
                    WorldGen.PlaceTile(StartBridgeX + 3 + i, BridgeY - 1, TileID.Rope);
                }
                int length = EndBridgeX - (StartBridgeX + 5) + 1;
                if (length % 2 == 0) {
                    WorldGen.PlaceTile(StartBridgeX + 3 + length / 2, BridgeY - 2, TileID.Rope);
                    WorldGen.PlaceTile(EndBridgeX - 3 - length / 2, BridgeY, TileID.Rope);
                    WorldGen.PlaceTile(-3 - length / 2, BridgeY + 1, TileID.Rope);
                }
                else {
                    WorldGen.PlaceTile(StartBridgeX + 3 + length / 2, BridgeY - 2, TileID.Rope);
                    WorldGen.PlaceTile(StartBridgeX + 3 + length / 2, BridgeY, TileID.Rope);
                    WorldGen.PlaceTile(StartBridgeX + 3 + length / 2, BridgeY + 1, TileID.Rope);
                }
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 25; j++) {
                        if (WorldMethods.CheckTile(StartBridgeX - 5 + i, BridgeY + j + 1, TileID.Sand)) {
                            WorldGen.SlopeTile(StartBridgeX - 5 + i, BridgeY + j + 1, 0);
                        }
                        WorldGen.PlaceTile(StartBridgeX - 5 + i, BridgeY + j, TileID.Sand);
                    }
                }
                #endregion
                #region Main Building
                int MainBuildingX = StartDesertVillageX - 37;
                int MainBuildingY = StartDesertVillageY;
                while (WorldGen.SolidTile(MainBuildingX, MainBuildingY)) { MainBuildingY--; }
                MainBuildingY -= 22;
                int n = 0;
                for (int i = 0; i < 24; i++) {
                    while (!WorldMethods.CheckTile(MainBuildingX + i, MainBuildingY + n, TileID.Sand)) {
                        WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + n, TileID.Sand);
                        n++;
                    }
                    n = 0;
                }
                int[,] MainBuildingTile = new int[,] {
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 1, 1, 1, 3, 3, 3, 1, 1, 1, 3, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
                       { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 2, 2, 2, 2, 2, 2, 2},
                       { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       { 0, 0, 0, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 1, 1, 0, 0, 0, 0, 0, 1, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 4, 1, 4, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 3, 1, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 3, 3, 3, 1, 1, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 4, 0, 0, 0, 0, 0, 0, 4, 2},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 3, 0, 0, 0, 0, 0, 0, 0, 2},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 6, 6, 2, 2, 2, 2, 2, 2, 2},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 0, 8, 8, 8, 0, 0, 8, 8, 0, 8, 0, 0, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 0, 0, 8, 0, 0, 0, 8, 0, 0, 0, 0, 0, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 0, 0, 9, 9, 0, 0, 9, 0, 9, 9, 0, 0, 7, 7, 5, 5, 5, 5, 5, 5, 5},
                       { 5, 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 5},
                };
                for (int j = 0; j < MainBuildingTile.GetLength(0); j++) {
                    for (int i = 0; i < MainBuildingTile.GetLength(1); i++) {
                        switch (MainBuildingTile[j, i]) {
                            case 0: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); break;
                            case 1: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.SandstoneBrick); break;
                            case 2: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.SandstoneBrick); WorldGen.paintTile(MainBuildingX + i, MainBuildingY + j, 27); break;
                            case 3: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, ModContent.TileType<PapuansPlatform>()); break;
                            case 4: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.PalmWood); break;
                            case 5: WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.Sand); break;
                            case 6: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.SandstoneBrick); WorldGen.paintTile(MainBuildingX + i, MainBuildingY + j, 27); WorldGen.PlaceWire(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceActuator(MainBuildingX + i, MainBuildingY + j); break;
                            case 7: WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.Sand); WorldGen.PlaceWire(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceActuator(MainBuildingX + i, MainBuildingY + j); break;
                            case 8: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.Cobweb); break;
                            case 9: WorldGen.KillTile(MainBuildingX + i, MainBuildingY + j); WorldGen.PlaceTile(MainBuildingX + i, MainBuildingY + j, TileID.BoneBlock); break;
                        }
                    }
                }
                int UnderY = MainBuildingY + 23;
                WorldGen.PlaceWall(MainBuildingX, MainBuildingY, WallID.PearlwoodFence);
                WorldGen.PlaceWall(MainBuildingX + 1, MainBuildingY, WallID.PearlwoodFence);
                WorldGen.Place3x2(MainBuildingX + 1, MainBuildingY + 22, (ushort)ModContent.TileType<TannedSkin>());
                WorldGen.Place2xX(MainBuildingX + 5, MainBuildingY + 15, TileID.SeaweedPlanter, 0);
                WorldGen.Place3x2(MainBuildingX + 8, MainBuildingY + 15, (ushort)ModContent.TileType<PapuansSofa>());
                WorldGen.Place1x2Top(MainBuildingX + 10, MainBuildingY + 11, 42, 7);
                WorldGen.Place1x2Top(MainBuildingX + 14, MainBuildingY + 5, (ushort)ModContent.TileType<PapuansLantern>(), 0);
                WorldGen.PlaceTile(MainBuildingX + 12, MainBuildingY + 7, ModContent.TileType<Content.Tiles.BookOfSecrets>());
                WorldGen.Place4x2(MainBuildingX + 14, MainBuildingY + 9, (ushort)ModContent.TileType<PapuansBed>(), 1);
                WorldGen.Place1xX(MainBuildingX + 13, MainBuildingY + 15, (ushort)ModContent.TileType<PapuansLamp>(), 0);
                WorldGen.Place1x2(MainBuildingX + 16, MainBuildingY + 13, (ushort)ModContent.TileType<OrnamentalPlant>(), 0);
                WorldGen.Place1x2Top(MainBuildingX + 10, MainBuildingY + 17, (ushort)ModContent.TileType<PapuansLantern>(), 0);
                WorldGen.PlaceTile(MainBuildingX + 18, MainBuildingY + 17, (ushort)ModContent.TileType<PapuansCandle>());
                WorldGen.Place1x1(MainBuildingX + 22, MainBuildingY + 16, TileID.BoneBlock, 0);
                WorldGen.Place3x2(MainBuildingX + 13, MainBuildingY + 22, (ushort)ModContent.TileType<PapuansTable>());
                WorldGen.Place1x2(MainBuildingX + 15, MainBuildingY + 22, (ushort)ModContent.TileType<PapuansChair>(), 0);
                WorldGen.PlaceOnTable1x1(MainBuildingX + 12, MainBuildingY + 20, 13, 6);
                WorldGen.Place2x1(MainBuildingX + 13, MainBuildingY + 20, 103, 3);
                WorldGen.Place1xX(MainBuildingX + 8, MainBuildingY + 22, (ushort)ModContent.TileType<PapuansDoorClosed>(), 0);
                WorldGen.Place1xX(MainBuildingX + 17, MainBuildingY + 22, (ushort)ModContent.TileType<PapuansDoorClosed>(), 0);
                WorldGen.Place1xX(MainBuildingX + 11, MainBuildingY + 15, (ushort)ModContent.TileType<PapuansDoorClosed>(), 0);
                WorldGen.Place1xX(MainBuildingX + 23, MainBuildingY + 22, (ushort)ModContent.TileType<PapuansDoorClosed>(), 0);
                WorldGen.PlaceObject(MainBuildingX + 20, MainBuildingY + 23, TileID.TrapdoorClosed);
                WorldGen.Place1x1(MainBuildingX + 16, MainBuildingY + 25, TileID.Books);
                WorldGen.PlaceTile(MainBuildingX + 22, MainBuildingY + 27, (ushort)ModContent.TileType<RuneTable>());
                int mainchest = WorldGen.PlaceChest(MainBuildingX + 14, MainBuildingY + 15, (ushort)ModContent.TileType<PapuansChest>(), false, 0);
                int mainchestIndex = Chest.FindChest(MainBuildingX + 14, MainBuildingY + 14);
                if (mainchestIndex != -1) { GenerateBiomeMainChestLoot(Main.chest[mainchestIndex].item); }
                WorldGen.PlaceWire(MainBuildingX + 17, UnderY + 4);
                WorldGen.PlaceWire(MainBuildingX + 17, UnderY + 3);
                WorldGen.PlaceWire(MainBuildingX + 17, UnderY + 2);
                WorldGen.PlaceWire(MainBuildingX + 18, UnderY + 2);
                WorldGen.PlaceWire(MainBuildingX + 15, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 14, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 14, UnderY + 12);
                WorldGen.Place1x2Top(MainBuildingX + 14, UnderY + 12, 42, 2);
                Tile tile1 = Framing.GetTileSafely(MainBuildingX + 14, UnderY + 12);
                Tile tile1under = Framing.GetTileSafely(MainBuildingX + 14, UnderY + 13);
                tile1.TileFrameX += 18;
                tile1under.TileFrameX += 18;
                WorldGen.PlaceWire(MainBuildingX + 13, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 12, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 11, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 10, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 9, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 9, UnderY + 12);
                WorldGen.Place1x2Top(MainBuildingX + 9, UnderY + 12, 42, 2);
                Tile tile2 = Framing.GetTileSafely(MainBuildingX + 9, UnderY + 12);
                Tile tile2under = Framing.GetTileSafely(MainBuildingX + 9, UnderY + 13);
                tile2.TileFrameX += 18;
                tile2under.TileFrameX += 18;
                WorldGen.PlaceWire(MainBuildingX + 8, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 7, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 6, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 5, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 4, UnderY + 11);
                WorldGen.PlaceWire(MainBuildingX + 4, UnderY + 12);
                WorldGen.Place1x2Top(MainBuildingX + 4, UnderY + 12, 42, 2);
                Tile tile3 = Framing.GetTileSafely(MainBuildingX + 4, UnderY + 12);
                Tile tile3under = Framing.GetTileSafely(MainBuildingX + 4, UnderY + 13);
                tile3.TileFrameX += 18;
                tile3under.TileFrameX += 18;
                int underchest = WorldGen.PlaceChest(MainBuildingX + 4, UnderY + 15, (ushort)ModContent.TileType<PapuansChest>());
                int underchestIndex = Chest.FindChest(MainBuildingX + 4, UnderY + 14);
                for (int i = 0; i < 14; i++) {
                    for (int k = 0; k < 4; k++) {
                        WorldGen.PlaceWall(MainBuildingX + 4 + i, UnderY + 15 - k, WallID.Sandstone);
                    }
                }
                if (underchestIndex != -1) {
                    GenerateBiomeUnderChestLoot(Main.chest[underchestIndex].item);
                }
                int[,] MainBuildingWall = new int[,] 
                { 
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 4, 5, 5, 5, 5, 5, 5, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 4, 5, 0, 5, 0, 0, 5, 0, 1, 1, 1, 1, 1, 0, 6, 7, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 1, 3, 1, 3, 1, 0, 7, 6, 6, 7, 0, 0, 0},
                      {0, 0, 0, 0, 4, 6, 0, 0, 0, 0, 0, 4, 1, 3, 1, 3, 1, 0, 0, 7, 6, 6, 6, 0, 0},
                      {0, 0, 0, 0, 4, 6, 6, 0, 0, 0, 7, 4, 1, 3, 1, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 4, 6, 6, 6, 7, 7, 6, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 3, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 3, 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 3, 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 3, 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1, 1, 3, 1, 3, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 3, 1, 0, 0},
                      {0, 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 2, 2, 2, 8, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 2, 2, 2, 8, 2, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 2, 2, 2, 8, 2, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 2, 2, 2, 8, 2, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 2, 2, 2, 8, 2, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
                for (int j = 0; j < MainBuildingWall.GetLength(0); j++) {
                    for (int i = 0; i < MainBuildingWall.GetLength(1); i++) {
                        switch (MainBuildingWall[j, i]) {
                            case 0:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            break;
                            case 1:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.StoneSlab);
                            break;
                            case 3:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.PearlwoodFence);
                            break;
                            case 4:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.PalmWoodFence);
                            break;
                            case 5:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.Sail);
                            WorldGen.paintWall(MainBuildingX + i, MainBuildingY + j, 12);
                            break;
                            case 6:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.Jungle);
                            break;
                            case 7:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.LivingLeaf);
                            break;
                            case 8:
                            WorldGen.KillWall(MainBuildingX + i, MainBuildingY + j);
                            WorldGen.PlaceWall(MainBuildingX + i, MainBuildingY + j, WallID.PalmWood);
                            break;
                        }
                    }
                }
                int[,] MainBuildingSlope = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 4, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < MainBuildingSlope.GetLength(0); j++) {
                    for (int i = 0; i < MainBuildingSlope.GetLength(1); i++) {
                        switch (MainBuildingSlope[j, i]) {
                            case 0:
                            break;
                            case 1:
                            WorldGen.SlopeTile(MainBuildingX + i, MainBuildingY + j, 1);
                            break;
                            case 2:
                            WorldGen.SlopeTile(MainBuildingX + i, MainBuildingY + j, 2);
                            break;
                            case 3:
                            WorldGen.SlopeTile(MainBuildingX + i, MainBuildingY + j, 3);
                            break;
                            case 4:
                            WorldGen.SlopeTile(MainBuildingX + i, MainBuildingY + j, 4);
                            break;
                            case 5:
                            Tile MainBuilding = Main.tile[MainBuildingX + i, MainBuildingY + j];
                            MainBuilding.IsHalfBlock = true;
                            break;
                        }
                    }
                }
                WorldGen.PlaceObject(MainBuildingX + 18, UnderY + 2, TileID.Lever);
                for (int j = 0; j < 5; j++) {
                    WorldMethods.BresenhamLineTunnel(MainBuildingX + 25, MainBuildingY + 22 - j, StartBridgeX - 2, BridgeY - 1 - j, 1);
                    WorldMethods.BresenhamLineTile(MainBuildingX + 25, MainBuildingY + 23 + j, StartBridgeX - 2, BridgeY + j, 1, TileID.Sand, 0);
                }
                #endregion
                #region Well
                int StartWellX = MainBuildingX - 7;
                int StartWellY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(StartWellX, StartWellY)) {
                    StartWellY++;
                }
                StartWellY -= 7;
                int[,] Well = new int[,] { 
                         { 0, 1, 1, 1, 1, 0 },
                         { 3, 10, 3, 3, 10, 3 },
                         { 0, 4, 0, 0, 4, 0 },
                         { 0, 4, 0, 0, 4, 0 },
                         { 0, 5, 5, 6, 5, 0 },
                         { 0, 4, 0, 7, 4, 0 },
                         { 0, 4, 0, 7, 4, 0 },
                         { 1, 1, 0, 7, 1, 1 },
                         { 9, 1, 2, 8, 1, 9 },
                         { 9, 1, 2, 2, 1, 9 },
                         { 9, 1, 2, 2, 1, 9 },
                         { 9, 1, 2, 2, 1, 9 },
                         { 9, 1, 1, 1, 1, 9 },
                };
                for (int j = 0; j < Well.GetLength(0); j++) {
                    for (int i = 0; i < Well.GetLength(1); i++) {
                        switch (Well[j, i]) {
                            case 0:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            break;
                            case 1:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.StoneSlab);
                            break;
                            case 3:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.StoneSlab);
                            break;
                            case 4:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.PalmWoodFence);
                            break;
                            case 5:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.PalmWood);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, ModContent.TileType<PapuansPlatform>());
                            break;
                            case 6:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.Chain);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.PalmWood);
                            break;
                            case 7:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.Chain);
                            break;
                            case 8:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.Chain);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.StoneSlab);
                            break;
                            case 10:
                            WorldGen.KillTile(StartWellX + i, StartWellY + j);
                            WorldGen.KillWall(StartWellX + i, StartWellY + j);
                            WorldGen.PlaceWall(StartWellX + i, StartWellY + j, WallID.PalmWoodFence);
                            WorldGen.PlaceTile(StartWellX + i, StartWellY + j, TileID.StoneSlab);
                            break;
                        }
                    }
                }
                Tile StartWell = Main.tile[StartWellX + 1, StartWellY];
                StartWell.IsHalfBlock = true;
                Tile StartWell2 = Main.tile[StartWellX + 2, StartWellY];
                StartWell2.IsHalfBlock = true;
                Tile StartWell3 = Main.tile[StartWellX + 3, StartWellY];
                StartWell3.IsHalfBlock = true;
                Tile StartWell4 = Main.tile[StartWellX + 4, StartWellY];
                StartWell4.IsHalfBlock = true;
                WorldGen.SlopeTile(StartWellX, StartWellY + 1, 4);
                WorldGen.SlopeTile(StartWellX + 5, StartWellY + 1, 3);
                Main.tile[StartWellX + 2, StartWellY + 11].LiquidAmount = 255;
                Main.tile[StartWellX + 3, StartWellY + 11].LiquidAmount = 255;
                Main.tile[StartWellX + 2, StartWellY + 10].LiquidAmount = 255;
                Main.tile[StartWellX + 3, StartWellY + 10].LiquidAmount = 255;
                Main.tile[StartWellX + 2, StartWellY + 9].LiquidAmount = 255;
                Main.tile[StartWellX + 3, StartWellY + 9].LiquidAmount = 255;
                #endregion
                #region Tailor Building
                int TailorBuildingX = StartWellX - 20;
                int TailorBuildingY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(TailorBuildingX, TailorBuildingY))
                    TailorBuildingY++;
                TailorBuildingY -= 15;
                int[,] TailorBuildingTile = new int[,]
                {
                       {0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0},
                       {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                       {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                       {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                       {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                       {0, 0, 1, 3, 0, 0, 0, 0, 3, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {4, 1, 1, 1, 4, 4, 4, 4, 1, 1, 1, 4},
                       {0, 0, 1, 3, 0, 0, 0, 0, 3, 1, 0, 0},
                       {0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5},
                       {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                       {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                       {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                       {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                };
                for (int j = 0; j < TailorBuildingTile.GetLength(0); j++) {
                    for (int i = 0; i < TailorBuildingTile.GetLength(1); i++) {
                        switch (TailorBuildingTile[j, i]) {
                            case 0:
                            WorldGen.KillTile(TailorBuildingX + i, TailorBuildingY + j);
                            break;
                            case 1:
                            WorldGen.KillTile(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceTile(TailorBuildingX + i, TailorBuildingY + j, TileID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillTile(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceTile(TailorBuildingX + i, TailorBuildingY + j, TileID.StoneSlab);
                            break;
                            case 3:
                            WorldGen.KillTile(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceTile(TailorBuildingX + i, TailorBuildingY + j, TileID.PalmWood);
                            break;
                            case 4:
                            WorldGen.KillTile(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceTile(TailorBuildingX + i, TailorBuildingY + j, ModContent.TileType<PapuansPlatform>());
                            break;
                            case 5:
                            WorldGen.SlopeTile(TailorBuildingX + i, TailorBuildingY + j, 0);
                            WorldGen.PlaceTile(TailorBuildingX + i, TailorBuildingY + j, TileID.Sand);
                            break;
                        }
                    }
                }
                WorldGen.Place1x2(TailorBuildingX + 1, TailorBuildingY + 8, (ushort)ModContent.TileType<OrnamentalPlant>(), 0);
                WorldGen.Place1x2(TailorBuildingX + 10, TailorBuildingY + 8, (ushort)ModContent.TileType<OrnamentalPlant>(), 0);
                WorldGen.Place2x1(TailorBuildingX + 6, TailorBuildingY + 8, (ushort)ModContent.TileType<PapuansWorkbench>());
                WorldGen.PlaceTile(TailorBuildingX + 3, TailorBuildingY + 14, (ushort)ModContent.TileType<PapuansCandle>());
                WorldGen.Place3x2(TailorBuildingX + 5, TailorBuildingY + 14, (ushort)ModContent.TileType<PapuansTable>());
                WorldGen.Place3x2(TailorBuildingX + 8, TailorBuildingY + 14, TileID.Loom);
                WorldGen.Place2x2(TailorBuildingX + 10, TailorBuildingY + 10, TileID.ItemFrame, 1);
                int tailorchest = WorldGen.PlaceChest(TailorBuildingX + 3, TailorBuildingY + 8, (ushort)ModContent.TileType<PapuansChest>(), false, 0);
                int tailorchestIndex = Chest.FindChest(TailorBuildingX + 3, TailorBuildingY + 7);
                if (tailorchestIndex != -1) {
                    GenerateBiomeTailorChestLoot(Main.chest[tailorchestIndex].item);
                }
                int[,] TailorBuildingWall = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                       { 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                       { 0, 0, 2, 1, 3, 1, 1, 3, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 3, 1, 1, 3, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 1, 1, 1, 1, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 1, 1, 1, 1, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 1, 1, 1, 1, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 3, 1, 1, 3, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 3, 1, 1, 3, 1, 2, 0, 0 },
                       { 0, 0, 2, 1, 1, 1, 1, 1, 1, 2, 0, 0 },
                       { 3, 3, 2, 1, 1, 1, 1, 1, 1, 2, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < TailorBuildingWall.GetLength(0); j++) {
                    for (int i = 0; i < TailorBuildingWall.GetLength(1); i++) {
                        switch (TailorBuildingWall[j, i]) {
                            case 0:
                            WorldGen.KillWall(TailorBuildingX + i, TailorBuildingY + j);
                            break;
                            case 1:
                            WorldGen.KillWall(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceWall(TailorBuildingX + i, TailorBuildingY + j, WallID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillWall(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceWall(TailorBuildingX + i, TailorBuildingY + j, WallID.PalmWoodFence);
                            break;
                            case 3:
                            WorldGen.KillWall(TailorBuildingX + i, TailorBuildingY + j);
                            WorldGen.PlaceWall(TailorBuildingX + i, TailorBuildingY + j, WallID.PearlwoodFence);
                            break;
                        }
                    }
                }
                int[,] TailorBuildingSlope = new int[,]
                {
                       {0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0},
                       {0, 0, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0},
                       {0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                       {0, 0, 0, 3, 0, 0, 0, 0, 4, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 3, 0, 0, 0, 0, 4, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
                for (int j = 0; j < TailorBuildingSlope.GetLength(0); j++) {
                    for (int i = 0; i < TailorBuildingSlope.GetLength(1); i++) {
                        switch (TailorBuildingSlope[j, i]) {
                            case 0:
                            break;
                            case 1:
                            WorldGen.SlopeTile(TailorBuildingX + i, TailorBuildingY + j, 1);
                            break;
                            case 2:
                            WorldGen.SlopeTile(TailorBuildingX + i, TailorBuildingY + j, 2);
                            break;
                            case 3:
                            WorldGen.SlopeTile(TailorBuildingX + i, TailorBuildingY + j, 3);
                            break;
                            case 4:
                            WorldGen.SlopeTile(TailorBuildingX + i, TailorBuildingY + j, 4);
                            break;
                            case 5:
                            Tile TailorBuilding = Main.tile[TailorBuildingX + i, TailorBuildingY + j];
                            TailorBuilding.IsHalfBlock = true;
                            break;
                        }
                    }
                }
                #endregion
                #region Tree
                int TreeStartX = EndBridgeX + 2;
                int TreeStartY = BridgeY - 20;
                while (!WorldGen.SolidTile(TreeStartX + 6, TreeStartY)) {
                    TreeStartY++;
                }
                for (int i = 0; i < 4; i++)
                    WorldGen.KillTile(TreeStartX + 5 + i, TreeStartY - 1);
                TreeStartY -= 12;
                int[,] TreeTile = new int[,] { { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                       { 0, 0, 1, 1, 0, 1, 1, 0, 0, 0 },
                       { 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                       { 0, 1, 0, 1, 1, 1, 0, 1, 1, 1 },
                       { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
                       { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                       { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
                       { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
                       { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                       { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
                       { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 },
                       { 0, 0, 0, 0, 0, 2, 2, 2, 2, 0 },
                };
                for (int j = 0; j < TreeTile.GetLength(0); j++) {
                    for (int i = 0; i < TreeTile.GetLength(1); i++) {
                        switch (TreeTile[j, i]) {
                            case 0:
                            break;
                            case 1:
                            WorldGen.PlaceTile(TreeStartX + i, TreeStartY + j, TileID.LivingMahogany);
                            Tile TreeStart = Main.tile[TreeStartX + i, TreeStartY + j];
                            TreeStart.IsActuated = true;
                            break;
                            case 2:
                            WorldGen.PlaceTile(TreeStartX + i, TreeStartY + j, TileID.Sand);
                            break;
                        }
                    }
                }
                int[,] TreeSlope = new int[,] {
                                            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 4, 0, 0, 2, 0, 0, 0, 0 },
                        { 0, 2, 0, 0, 1, 0, 0, 0, 0, 0 },
                        { 0, 3, 0, 4, 0, 0, 0, 2, 0, 3 },
                        { 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 },
                        { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                };
                for (int j = 0; j < TreeSlope.GetLength(0); j++) {
                    for (int i = 0; i < TreeSlope.GetLength(1); i++) {
                        switch (TreeSlope[j, i]) {
                            case 0:
                            break;
                            case 1:
                            WorldGen.SlopeTile(TreeStartX + i, TreeStartY + j, 1);
                            break;
                            case 2:
                            WorldGen.SlopeTile(TreeStartX + i, TreeStartY + j, 2);
                            break;
                            case 3:
                            WorldGen.SlopeTile(TreeStartX + i, TreeStartY + j, 3);
                            break;
                            case 4:
                            WorldGen.SlopeTile(TreeStartX + i, TreeStartY + j, 4);
                            break;
                        }
                    }
                }
                #endregion
                #region Campfires
                int FireStart1X = TreeStartX + 14;
                int FireStart1Y = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(FireStart1X, FireStart1Y)) {
                    FireStart1Y++;
                }
                FireStart1Y -= 4;
                int[,] Fire1 = new int[,] { { 3, 0, 0, 0, 3 },
                        { 4, 5, 5, 5, 4 },
                        { 2, 0, 0, 0, 2 },
                        { 2, 0, 0, 0, 2 },
                        { 1, 1, 1, 1, 1 },
                        { 6, 6, 6, 6, 6 },
                };
                for (int j = 0; j < Fire1.GetLength(0); j++) {
                    for (int i = 0; i < Fire1.GetLength(1); i++) {
                        switch (Fire1[j, i]) {
                            case 0:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            break;
                            case 1:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            WorldGen.PlaceTile(FireStart1X + i, FireStart1Y + j, TileID.Stone);
                            break;
                            case 2:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            WorldGen.KillWall(FireStart1X + i, FireStart1Y + j);
                            WorldGen.PlaceWall(FireStart1X + i, FireStart1Y + j, WallID.PalmWoodFence);
                            break;
                            case 3:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            WorldGen.KillWall(FireStart1X + i, FireStart1Y + j);
                            WorldGen.PlaceWall(FireStart1X + i, FireStart1Y + j, WallID.PearlwoodFence);
                            break;
                            case 4:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            WorldGen.KillWall(FireStart1X + i, FireStart1Y + j);
                            WorldGen.PlaceTile(FireStart1X + i, FireStart1Y + j, ModContent.TileType<PapuansPlatform>());
                            WorldGen.PlaceWall(FireStart1X + i, FireStart1Y + j, WallID.PearlwoodFence);
                            break;
                            case 5:
                            WorldGen.KillTile(FireStart1X + i, FireStart1Y + j);
                            WorldGen.PlaceTile(FireStart1X + i, FireStart1Y + j, ModContent.TileType<PapuansPlatform>());
                            break;
                            case 6:
                            WorldGen.PlaceTile(FireStart1X + i, FireStart1Y + j, TileID.Sand);
                            break;
                        }
                    }
                }
                WorldGen.Place3x2(FireStart1X + 2, FireStart1Y + 3, TileID.Campfire);
                int FireStart2X = FireStart1X + 15;
                int FireStart2Y = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(FireStart2X, FireStart2Y)) {
                    FireStart2Y++;
                }
                FireStart2Y -= 4;
                int[,] Fire2 = new int[,] { { 3, 0, 0, 0, 3 },
                        { 4, 5, 5, 5, 4 },
                        { 2, 0, 0, 0, 2 },
                        { 2, 0, 0, 0, 2 },
                        { 1, 1, 1, 1, 1 },
                        { 6, 6, 6, 6, 6 },
                };
                for (int j = 0; j < Fire2.GetLength(0); j++) {
                    for (int i = 0; i < Fire2.GetLength(1); i++) {
                        switch (Fire2[j, i]) {
                            case 0:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            break;
                            case 1:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            WorldGen.PlaceTile(FireStart2X + i, FireStart2Y + j, TileID.Stone);
                            break;
                            case 2:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            WorldGen.KillWall(FireStart2X + i, FireStart2Y + j);
                            WorldGen.PlaceWall(FireStart2X + i, FireStart2Y + j, WallID.PalmWoodFence);
                            break;
                            case 3:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            WorldGen.KillWall(FireStart2X + i, FireStart2Y + j);
                            WorldGen.PlaceWall(FireStart2X + i, FireStart2Y + j, WallID.PearlwoodFence);
                            break;
                            case 4:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            WorldGen.KillWall(FireStart2X + i, FireStart2Y + j);
                            WorldGen.PlaceTile(FireStart2X + i, FireStart2Y + j, ModContent.TileType<PapuansPlatform>());
                            WorldGen.PlaceWall(FireStart2X + i, FireStart2Y + j, WallID.PearlwoodFence);
                            break;
                            case 5:
                            WorldGen.KillTile(FireStart2X + i, FireStart2Y + j);
                            WorldGen.PlaceTile(FireStart2X + i, FireStart2Y + j, ModContent.TileType<PapuansPlatform>());
                            break;
                            case 6:
                            WorldGen.PlaceTile(FireStart2X + i, FireStart2Y + j, TileID.Sand);
                            break;
                        }
                    }
                }
                #endregion
                #region Statue
                int statueX = FireStart1X + 10;
                int statueY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(statueX, statueY))
                    statueY++;
                statueY -= 3;
                TotemX = statueX;
                TotemY = statueY;
                WorldGen.KillTile(statueX - 1, statueY);
                WorldGen.KillTile(statueX, statueY);
                WorldGen.KillTile(statueX - 1, statueY + 1);
                WorldGen.KillTile(statueX, statueY + 1);
                WorldGen.KillTile(statueX - 1, statueY + 2);
                WorldGen.KillTile(statueX, statueY + 2);
                WorldGen.KillTile(statueX - 1, statueY + 3);
                WorldGen.KillTile(statueX, statueY + 3);
                WorldGen.KillTile(statueX - 1, statueY - 1);
                WorldGen.KillTile(statueX, statueY - 1);
                WorldGen.KillTile(statueX - 1, statueY - 2);
                WorldGen.KillTile(statueX, statueY - 2);
                WorldGen.PlaceTile(statueX - 1, statueY + 3, TileID.Stone);
                WorldGen.PlaceTile(statueX, statueY + 3, TileID.Stone);
                WorldGen.PlaceObject(statueX, statueY, ModContent.TileType<TotemOfCurse>());
                WorldGen.Place3x2(FireStart2X + 2, FireStart2Y + 3, TileID.Campfire);
                #endregion
                #region Forge
                int ForgeStartX = FireStart2X + 16;
                int ForgeStartY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(ForgeStartX, ForgeStartY)) {
                    ForgeStartY++;
                }
                ForgeStartY -= 13;
                int[,] ForgeTile = new int[,]
                {
                   { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                   { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0 },
                   { 0, 0, 0, 1, 4, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 3, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3 },
                   { 0, 0, 0, 1, 4, 5, 5, 0, 0, 0, 0, 0, 4, 1, 4, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 1, 0, 5, 5, 0, 3, 3, 3, 3, 3, 1, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                   { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                };
                for (int j = 0; j < ForgeTile.GetLength(0); j++) {
                    for (int i = 0; i < ForgeTile.GetLength(1); i++) {
                        switch (ForgeTile[j, i]) {
                            case 0:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            break;
                            case 1:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, TileID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, TileID.StoneSlab);
                            break;
                            case 3:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, ModContent.TileType<PapuansPlatform>());
                            break;
                            case 4:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, TileID.PalmWood);
                            break;
                            case 5:
                            WorldGen.KillTile(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, TileID.Rope);
                            break;
                            case 6:
                            WorldGen.PlaceTile(ForgeStartX + i, ForgeStartY + j, TileID.Sand);
                            WorldGen.SlopeTile(ForgeStartX + i, ForgeStartY + j, 0);
                            break;
                        }
                    }
                }
                WorldGen.Place1x2Top(ForgeStartX + 5, ForgeStartY + 4, (ushort)ModContent.TileType<PapuansLantern>(), 0);
                WorldGen.Place1x2Top(ForgeStartX + 11, ForgeStartY + 4, (ushort)ModContent.TileType<PapuansLantern>(), 0);
                int forgechest = WorldGen.PlaceChest(ForgeStartX + 8, ForgeStartY + 7, (ushort)ModContent.TileType<PapuansChest>(), false, 0);
                int forgechestIndex = Chest.FindChest(ForgeStartX + 8, ForgeStartY + 6);
                if (forgechestIndex != -1) {
                    GenerateBiomeForgeChestLoot(Main.chest[forgechestIndex].item);
                }
                WorldGen.Place2x2(ForgeStartX + 11, ForgeStartY + 7, TileID.FishingCrate, 0);
                WorldGen.Place2x2(ForgeStartX + 13, ForgeStartY + 7, TileID.FishingCrate, 0);
                WorldGen.PlaceObject(ForgeStartX + 5, ForgeStartY + 8, TileID.TrapdoorClosed);
                WorldGen.Place2x2(ForgeStartX + 1, ForgeStartY + 9, TileID.ItemFrame, 1);
                WorldGen.PlaceTile(ForgeStartX + 8, ForgeStartY + 9, TileID.Chain);
                WorldGen.PlaceTile(ForgeStartX + 9, ForgeStartY + 9, TileID.Bottles);
                WorldGen.PlaceTile(ForgeStartX + 10, ForgeStartY + 9, TileID.MetalBars, false, false, -1, 3);
                WorldGen.PlaceTile(ForgeStartX + 11, ForgeStartY + 9, TileID.MetalBars, false, false, -1, 3);
                WorldGen.Place2x1(ForgeStartX + 8, ForgeStartY + 13, TileID.Anvils, 1);
                WorldGen.Place3x2(ForgeStartX + 11, ForgeStartY + 13, TileID.Furnaces);
                WorldGen.Place1xX(ForgeStartX + 17, ForgeStartY + 12, (ushort)ModContent.TileType<PapuansLamp>());
                WorldGen.Place1xX(ForgeStartX + 3, ForgeStartY + 13, (ushort)ModContent.TileType<PapuansDoorClosed>());
                WorldGen.Place1xX(ForgeStartX + 13, ForgeStartY + 13, (ushort)ModContent.TileType<PapuansDoorClosed>());
                int[,] ForgeWall = new int[,]
                  {
                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 4, 1, 2, 1, 2, 1, 2, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 4, 1, 2, 1, 2, 1, 2, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0, 2 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 3, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 4 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 3, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 4 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 3, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 4 },
                  { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4 },
                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                  };
                for (int j = 0; j < ForgeWall.GetLength(0); j++) {
                    for (int i = 0; i < ForgeWall.GetLength(1); i++) {
                        switch (ForgeWall[j, i]) {
                            case 0:
                            WorldGen.KillWall(ForgeStartX + i, ForgeStartY + j);
                            break;
                            case 1:
                            WorldGen.KillWall(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceWall(ForgeStartX + i, ForgeStartY + j, WallID.SandstoneBrick);
                            break;
                            case 2:
                            WorldGen.KillWall(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceWall(ForgeStartX + i, ForgeStartY + j, WallID.PearlwoodFence);
                            break;
                            case 3:
                            WorldGen.KillWall(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceWall(ForgeStartX + i, ForgeStartY + j, WallID.MetalFence);
                            break;
                            case 4:
                            WorldGen.KillWall(ForgeStartX + i, ForgeStartY + j);
                            WorldGen.PlaceWall(ForgeStartX + i, ForgeStartY + j, WallID.PalmWoodFence);
                            break;
                        }
                    }
                }
                int[,] ForgeSlope = new int[,]
{
                   { 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0 },
};
                for (int j = 0; j < ForgeSlope.GetLength(0); j++) {
                    for (int i = 0; i < ForgeSlope.GetLength(1); i++) {
                        switch (ForgeSlope[j, i]) {
                            case 0:
                            break;
                            case 1:
                            WorldGen.SlopeTile(ForgeStartX + i, ForgeStartY + j, 1);
                            break;
                            case 2:
                            WorldGen.SlopeTile(ForgeStartX + i, ForgeStartY + j, 2);
                            break;
                            case 3:
                            WorldGen.SlopeTile(ForgeStartX + i, ForgeStartY + j, 3);
                            break;
                            case 4:
                            WorldGen.SlopeTile(ForgeStartX + i, ForgeStartY + j, 4);
                            break;
                            case 5:
                            Tile ForgeStar = Main.tile[ForgeStartX + i, ForgeStartY + j];
                            ForgeStar.IsHalfBlock = true;
                            break;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
    }
}