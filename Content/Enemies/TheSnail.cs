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
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

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
            NPC.damage = 1;
            NPC.lifeMax = 5;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 67; // Snail AI
            AIType = NPCID.Snail; // Inherit movement from Snail
            AnimationType = NPCID.Snail;

            //SpawnModBiomes = new int[1] { ModContent.GetInstance<HeavenBiome>().Type };
        }

        public override void AI()
        {
            NPC.active = true;
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            // Distance check
            float speed = 0.8f; // Adjust this to control the speed

            Vector2 direction = player.Center - NPC.Center;
            
            direction.Normalize();
            NPC.velocity.X = direction.X * speed; // Move towards player
       

            base.AI();

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.statLife = 0; // Set player health to zero
            target.KillMe(PlayerDeathReason.ByCustomReason($"{target.name} was touched by The Snail."), 1, 0);
        }
    }
}
