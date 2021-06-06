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
    public class SleekGunBarrel : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("increases the max number of bullets shot before having to reload by 15%\nincreases reload speed by 6%");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = 3;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            //item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.06f;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Accessories.SpareAmmo>(), 1);
            recipe.AddIngredient(ItemID.Barrel, 1);
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
