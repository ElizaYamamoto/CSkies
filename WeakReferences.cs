﻿using CSkies.Items.Summons;
using System;
using Terraria.ModLoader;

namespace CSkies
{
    internal class WeakReferences
    {
        public static void PerformModSupport()
        {
            PerformBossChecklistSupport();
        }

        private static void PerformBossChecklistSupport()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");

            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Observer", 5.5, (Func<bool>)(() => CWorld.downedObserver), "Use a [i:" + ModContent.ItemType<CosmicEye>() + "] at night");
                bossChecklist.Call("AddBossWithInfo", "Observer Void", 14, (Func<bool>)(() => CWorld.downedObserverV), "Use a [i:" + ModContent.ItemType<VoidEye>() + "] at night");
                bossChecklist.Call("AddBossWithInfo", "VOID", 14, (Func<bool>)(() => CWorld.downedObserverV), "Get Observer Void to half health in Expert Mode", CWorld.downedVoid);

                // SlimeKing = 1f;
                // EyeOfCthulhu = 2f;
                // EaterOfWorlds = 3f;
                // QueenBee = 4f;
                // Skeletron = 5f;
                // WallOfFlesh = 6f;
                // TheTwins = 7f;
                // TheDestroyer = 8f;
                // SkeletronPrime = 9f;
                // Plantera = 10f;
                // Golem = 11f;
                // DukeFishron = 12f;
                // LunaticCultist = 13f;
                // Moonlord = 14f;
            }
        }
    }
}
