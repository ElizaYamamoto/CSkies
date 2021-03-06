using Terraria.ModLoader;
using Terraria.ID;

namespace CSkies.Items.Observatory
{
    public class ObservatoryKey : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Key");
			Tooltip.SetDefault("'Unlocks the power of the blazing sun'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = ItemRarityID.LightPurple;
            item.maxStack = 99;
			item.value = 800000;
            item.noMelee = true;
        }

       
    }
}
