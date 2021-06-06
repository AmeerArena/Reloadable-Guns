using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Items.Accessories
{
    public class SpareAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("increases the max number of bullets shot before having to reload by 10%");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item item = player.HeldItem;
            //item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.1f;
        }
    }
}
