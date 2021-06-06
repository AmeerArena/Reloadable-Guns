using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Buffs
{
    public class ReloadBuff : ModBuff
    {
        public int Timer;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Reloading");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
        public int SP = 5;
        public override void Update(Player player, ref int buffIndex)
        {
            player.delayUseItem = true;
            SP--;
            if (SP <= 0)
            {
                SP = 5;
            }
            Timer++;
            if (Timer >= 18)
            {
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 108);
                Timer = 0;
            }

            if (player.buffTime[buffIndex] <= 2)
            {
                Item item = player.HeldItem;
                var modPlayer = Main.LocalPlayer.GetModPlayer<RGPlayer>();
                item.GetGlobalItem<RGGlobalItem>().AmmoNum = item.GetGlobalItem<RGGlobalItem>().AmmoMax2;
                player.AddBuff(ModContent.BuffType<FireingMomentBuff>(), 360);
            }
        }
    }
}
