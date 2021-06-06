using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

namespace ReloadableGuns
{
    public class RGGlobalItem : GlobalItem
    {
        public int AmmoNum;
        public int AmmoMax;
        public int AmmoMax2;
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            RGGlobalItem myClone = (RGGlobalItem)base.Clone(item, itemClone);
            myClone.AmmoNum = AmmoNum;
            myClone.AmmoMax = AmmoMax;
            myClone.AmmoMax2 = AmmoMax2;
            return myClone;
        }
        public override void SetDefaults(Item item)
        {
            if (item.ranged = true && item.useAmmo == AmmoID.Bullet)
            {
                AmmoNum = 40;
                AmmoMax = 40;
                AmmoMax2 = AmmoMax;
                item.damage += (int)(item.damage * 0.12f);

                if (item.type == ItemID.FlintlockPistol || item.type == ItemID.Musket || item.type == ItemID.TheUndertaker || item.type == ItemID.SniperRifle)
                {
                    AmmoNum = 7;
                    AmmoMax = 7;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.type == ItemID.Boomstick || item.type == ItemID.Revolver || item.type == ItemID.Handgun)
                {
                    AmmoNum = 20;
                    AmmoMax = 20;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.type == ItemID.Minishark || item.type == ItemID.Megashark)
                {
                    AmmoNum = 55;
                    AmmoMax = 55;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.type == ItemID.Xenopopper || item.type == ItemID.VortexBeater)
                {
                    AmmoNum = 100;
                    AmmoMax = 100;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.type == ItemID.ChainGun || item.type == ItemID.SDMG)
                {
                    AmmoNum = 200;
                    AmmoMax = 200;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.useTime <= 4)
                {
                    AmmoNum = 110;
                    AmmoMax = 110;
                    AmmoMax2 = AmmoMax;
                }
                else if (item.useTime <= 7)
                {
                    AmmoNum = 75;
                    AmmoMax = 75;
                    AmmoMax2 = AmmoMax;
                }
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            var modplayer = player.GetModPlayer<RGPlayer>();
            if (item.ranged = true && item.useAmmo == AmmoID.Bullet)
            {
                if (AmmoNum <= 0)
                {
                    return false;
                }
                else
                {
                    AmmoNum--;
                    if (player.HasBuff(ModContent.BuffType<Buffs.FireingMomentBuff>()))
                    {
                        player.ClearBuff(ModContent.BuffType<Buffs.FireingMomentBuff>());
                    }
                    return true;
                }
            }
            if (player.HeldItem.IsAir)
            {
                return true;
            }
            return base.CanUseItem(item, player);
        }
    }
}
