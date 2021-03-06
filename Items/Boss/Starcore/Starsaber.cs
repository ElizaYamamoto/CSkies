using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CSkies.Items.Boss.Starcore
{
    public class Starsaber : ModItem
	{
		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("Fires Homing stars");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.magic = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = mod.ProjectileType("StarPro");
			item.shootSpeed = 8f;
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item15;
            item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenPhaseblade);
            recipe.AddIngredient(mod, "Stelarite", 5);
            recipe.AddIngredient(mod, "CosmicStar", 2);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}


        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Glowmasks/Starsaber_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
