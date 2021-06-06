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
    [AutoloadEquip(EquipType.HandsOff)]
    public class GoldenRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("increases the max number of bullets shot before having to reload by 22%\nincreases reload speed by 12%\ngun crits replenish ammo\nincreases view range for guns\n10% increased ranged damage and critical strike chance");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 6, 0, 0);
            item.rare = 7;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.12f;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.22f;
            player.GetModPlayer<RGPlayer>().CritBullet = true;
            player.rangedDamage += 0.1f;
            player.rangedCrit += 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Accessories.GoldenGun>(), 1);
            recipe.AddIngredient(ItemID.SniperScope, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
