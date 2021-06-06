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
    [AutoloadEquip(EquipType.Waist)]
    public class ShroomiteMagazine : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("increases the max number of bullets shot before having to reload by 40%\nincreases reload speed by 20%");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 6, 50, 0);
            item.rare = 8;
            item.accessory = true;
            item.defense = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            //item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.2f;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Accessories.BackupMagazine>(), 1);
            recipe.AddIngredient(ItemID.ShroomiteBar, 6);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
