using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Buffs
{
    public class MagBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fast Mag");
            Description.SetDefault("you reload 33% faster");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.333f;
        }
    }
}
