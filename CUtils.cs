﻿using Microsoft.Xna.Framework;
using Terraria;

namespace CSkies
{
    public class Colors
    {
        public static Color COLOR_GLOWPULSE => Color.White * (Main.mouseTextColor / 255f);

        public static Color Flash => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, Color.Transparent, Color.White, Color.Transparent);
        public static Color FlashInverse => BaseUtility.MultiLerpColor(Main.LocalPlayer.miscCounter % 100 / 100f, Color.White, Color.Transparent, Color.White);

        public static Color Rarity12 => new Color(239, 0, 243);

        public static Color Rarity13 => new Color(0, 125, 243);

        public static Color Rarity14 => new Color(255, 22, 0);

        public static Color Rarity15 => new Color(0, 178, 107);
    }

    public static class CUtils
    {
        public static void DropLoot(this Entity ent, int type, int stack = 1)
        {
            Item.NewItem(ent.Hitbox, type, stack);
        }

        public static void DropLoot(this Entity ent, int type, float chance)
        {
            if (Main.rand.NextDouble() < chance)
            {
                Item.NewItem(ent.Hitbox, type);
            }
        }

        public static void DropLoot(this Entity ent, int type, int min, int max)
        {
            Item.NewItem(ent.Hitbox, type, Main.rand.Next(min, max));
        }

        public static bool AnyProjectiles(int type)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].type == type)
                {
                    return true;
                }
            }
            return false;
        }

        public static int CountProjectiles(int type)
        {
            int p = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].type == type)
                {
                    p++;
                }
            }
            return p;
        }

        public static void ObectPlace(int x, int y, int type)
        {
            WorldGen.PlaceObject(x, y, type);
            NetMessage.SendObjectPlacment(-1, x, y, type, 0, 0, -1, -1);
        }
    }
}
