using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CSkies.Items.Boss.Observer
{
    public class CometFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comet Fragment");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 3));
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
			item.maxStack = 99;
            item.rare = ItemRarityID.Green;
            item.value = 10000;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = Main.itemTexture[item.type];
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
