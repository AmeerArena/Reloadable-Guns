using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReloadableGuns.Items.Accessories
{
    public class EnchantedBulletCoating : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("gun crits replenish ammo");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            //item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().CritBullet = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
