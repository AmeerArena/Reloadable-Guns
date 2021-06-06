using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReloadableGuns.Items
{
    public class MagPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("reduces gun reloading time by 33%");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(silver: 2);
            item.buffType = ModContent.BuffType<Buffs.MagBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 25200; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 5);
            recipe.AddIngredient(ItemID.Lens, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
