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
    public class GoldenGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("increases the max number of bullets shot before having to reload by 20%\nincreases reload speed by 10%\ngun crits replenish ammo\n+5% bullet damage");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.1f;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.2f;
            player.GetModPlayer<RGPlayer>().CritBullet = true;
            player.bulletDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Accessories.SleekGunBarrel>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Accessories.EnchantedBulletCoating>(), 1);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
