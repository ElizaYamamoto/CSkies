using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CSkies.Items.Boss.Void
{
    public class ObserverVoidBag : ModItem
	{
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 36;
			item.height = 32;
            item.expert = true; item.expertOnly = true;
		}

        public override int BossBagNPC => mod.NPCType("ObserverVoid");

        public override bool CanRightClick()
		{
			return true;
        }

        public override void OpenBossBag(Player player)
        {
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("VOIDMask"));
            }
            string[] lootTableA = { "Singularity", "VoidFan", "VoidShot", "VoidJavelin", "VoidWings", "VoidPortal" };
            int lootA = Main.rand.Next(lootTableA.Length);
            player.QuickSpawnItem(mod.ItemType(lootTableA[lootA]));

            player.QuickSpawnItem(ModContent.ItemType<VoidFragment>(), Main.rand.Next(10, 15));

            player.QuickSpawnItem(mod.ItemType("ObserverVoidEye"));
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D glow = mod.GetTexture("Glowmasks/ObserverVoidBag_Glow");
            spriteBatch.Draw
                (
                glow,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - glow.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, glow.Width, glow.Height),
                Colors.Flash,
                rotation,
                glow.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
                );
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D glow = mod.GetTexture("Glowmasks/ObserverVoidBag_Glow");
            Texture2D texture2 = Main.itemTexture[item.type];
            spriteBatch.Draw(texture2, position, null, drawColor, 0, origin, scale, SpriteEffects.None, 0f);
            for (int i = 0; i < 4; i++)
            {
                //Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(glow, position, null, Colors.Flash, 0, origin, scale, SpriteEffects.None, 0f);

            }

            return false;
        }
    }
}