using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReloadableGuns
{
    public class RGGlobalNpc : GlobalNPC
    {
        public override bool InstancePerEntity => true;
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Accessories.SpareAmmo>());
				nextSlot++;
			}
		}
	}
}
