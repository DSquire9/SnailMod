using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace SnailMod.Content.Enemies
{
    public class TheSnail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
        }

        public override void SetDefaults()
        {
            // Change stats
            NPC.immortal = true;
            NPC.width = 18;
            NPC.height = 14;
            NPC.damage = 0;
            NPC.lifeMax = 5;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCID.Snail;
            AIType = NPCID.Snail;
            AnimationType = NPCID.Snail;

            //SpawnModBiomes = new int[1] { ModContent.GetInstance<HeavenBiome>().Type };
        }
    }
}
