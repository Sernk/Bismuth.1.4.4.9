using System;
using System.ComponentModel;
using System.Reflection;
using MonoMod.RuntimeDetour;
using Terraria.DataStructures;

namespace Bismuth.Utilities.ModSupport.BismuthHooks {
    public static class On_BismuthWorld {
        private static Type Target => typeof(BismuthWorld);

        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        // =====================================================
        // DoCastleside
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoCastleside(BismuthWorld world);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoCastleside(orig_DoCastleside orig, BismuthWorld world);

        static Hook Hook_DoCastleside;

        public static event hook_DoCastleside DoCastleside {
            add {
                Hook_DoCastleside = new Hook(Target.GetMethod("DoCastleside", Flags), value);
                Hook_DoCastleside.Apply();
            }
            remove => Hook_DoCastleside?.Dispose();
        }

        // =====================================================
        // TravelingVampireShop
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_TravelingVampireShop(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_TravelingVampireShop(orig_TravelingVampireShop orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_TravelingVampireShop;

        public static event hook_TravelingVampireShop TravelingVampireShop {
            add {
                Hook_TravelingVampireShop = new Hook(Target.GetMethod("TravelingVampireShop", Flags), value);
                Hook_TravelingVampireShop.Apply();
            }
            remove => Hook_TravelingVampireShop?.Dispose();
        }

        // =====================================================
        // SpawnTravelingVampire
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_SpawnTravelingVampire(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_SpawnTravelingVampire(orig_SpawnTravelingVampire orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_SpawnTravelingVampire;

        public static event hook_SpawnTravelingVampire SpawnTravelingVampire {
            add {
                Hook_SpawnTravelingVampire = new Hook(Target.GetMethod("SpawnTravelingVampire", Flags), value);
                Hook_SpawnTravelingVampire.Apply();
            }
            remove => Hook_SpawnTravelingVampire?.Dispose();
        }

        // =====================================================
        // OrcishInvasion
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_OrcishInvasion(BismuthWorld world);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_OrcishInvasion(orig_OrcishInvasion orig, BismuthWorld world);

        static Hook Hook_OrcishInvasion;

        public static event hook_OrcishInvasion OrcishInvasion {
            add {
                Hook_OrcishInvasion = new Hook(Target.GetMethod("OrcishInvasion", Flags), value);
                Hook_OrcishInvasion.Apply();
            }
            remove => Hook_OrcishInvasion?.Dispose();
        }

        // =====================================================
        // DoGenCrypt
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoGenCrypt(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoGenCrypt(orig_DoGenCrypt orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_DoGenCrypt;

        public static event hook_DoGenCrypt DoGenCrypt {
            add {
                Hook_DoGenCrypt = new Hook(Target.GetMethod("DoGenCrypt", Flags), value);
                Hook_DoGenCrypt.Apply();
            }
            remove => Hook_DoGenCrypt?.Dispose();
        }

        // =====================================================
        // StatueBuffUpdate
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_StatueBuffUpdate(BismuthWorld world);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_StatueBuffUpdate(orig_StatueBuffUpdate orig, BismuthWorld world);

        static Hook Hook_StatueBuffUpdate;

        public static event hook_StatueBuffUpdate StatueBuffUpdate {
            add {
                Hook_StatueBuffUpdate = new Hook(Target.GetMethod("StatueBuffUpdate", Flags), value);
                Hook_StatueBuffUpdate.Apply();
            }
            remove => Hook_StatueBuffUpdate?.Dispose();
        }

        // =====================================================
        // DoSpawnNecromant
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoSpawnNecromant(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoSpawnNecromant(orig_DoSpawnNecromant orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_DoSpawnNecromant;

        public static event hook_DoSpawnNecromant DoSpawnNecromant {
            add {
                Hook_DoSpawnNecromant = new Hook(Target.GetMethod("DoSpawnNecromant", Flags), value);
                Hook_DoSpawnNecromant.Apply();
            }
            remove => Hook_DoSpawnNecromant?.Dispose();
        }

        // =====================================================
        // DoSpawnMinotaur
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoSpawnMinotaur(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoSpawnMinotaur(orig_DoSpawnMinotaur orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_DoSpawnMinotaur;

        public static event hook_DoSpawnMinotaur DoSpawnMinotaur {
            add {
                Hook_DoSpawnMinotaur = new Hook(Target.GetMethod("DoSpawnMinotaur", Flags), value);
                Hook_DoSpawnMinotaur.Apply();
            }
            remove => Hook_DoSpawnMinotaur?.Dispose();
        }

        // =====================================================
        // DoSpawnBabaYaga
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoSpawnBabaYaga(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoSpawnBabaYaga(orig_DoSpawnBabaYaga orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_DoSpawnBabaYaga;

        public static event hook_DoSpawnBabaYaga DoSpawnBabaYaga {
            add {
                Hook_DoSpawnBabaYaga = new Hook(Target.GetMethod("DoSpawnBabaYaga", Flags), value);
                Hook_DoSpawnBabaYaga.Apply();
            }
            remove => Hook_DoSpawnBabaYaga?.Dispose();
        }

        // =====================================================
        // DoGenGenSunrise
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoGenGenSunrise(BismuthWorld world, int x, int y);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoGenGenSunrise(orig_DoGenGenSunrise orig, BismuthWorld world, int x, int y);

        static Hook Hook_DoGenGenSunrise;

        public static event hook_DoGenGenSunrise DoGenGenSunrise {
            add {
                Hook_DoGenGenSunrise = new Hook(Target.GetMethod("DoGenGenSunrise", Flags), value);
                Hook_DoGenGenSunrise.Apply();
            }
            remove => Hook_DoGenGenSunrise?.Dispose();
        }

        // =====================================================
        // DoEditWaterTemple
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_DoEditWaterTemple(BismuthWorld world);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_DoEditWaterTemple(orig_DoEditWaterTemple orig, BismuthWorld world);

        static Hook Hook_DoEditWaterTemple;

        public static event hook_DoEditWaterTemple DoEditWaterTemple {
            add {
                Hook_DoEditWaterTemple = new Hook(Target.GetMethod("DoEditWaterTemple", Flags), value);
                Hook_DoEditWaterTemple.Apply();
            }
            remove => Hook_DoEditWaterTemple?.Dispose();
        }

        // =====================================================
        // SpawnOldmanPriest
        // =====================================================

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void orig_SpawnOldmanPriest(BismuthWorld world, IEntitySource source);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void hook_SpawnOldmanPriest(orig_SpawnOldmanPriest orig, BismuthWorld world, IEntitySource source);

        static Hook Hook_SpawnOldmanPriest;

        public static event hook_SpawnOldmanPriest SpawnOldmanPriest {
            add {
                Hook_SpawnOldmanPriest = new Hook(Target.GetMethod("SpawnOldmanPriest", Flags), value);
                Hook_SpawnOldmanPriest.Apply();
            }
            remove => Hook_SpawnOldmanPriest?.Dispose();
        }

    }
}