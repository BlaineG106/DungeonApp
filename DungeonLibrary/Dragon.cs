using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {
        

        //properties
        public bool IsArmoured { get; set; }

        //CTOR
        public Dragon(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isArmoured):base(name, life, maxLife, minDamage, block, hitChance, maxDamage, description)
        {
            IsArmoured = isArmoured;
        }//end FQCTOR

        public Dragon()
        {
            MaxLife = 8;
            MaxDamage = 6;
            Name = "Baby Dragon";
            Life = 8;
            MinDamage = 2;
            HitChance = 25;
            Block = 20;
            Description = "A freshly hatched dragon capable of flight and shooting fireballs, even though its young it is still very dangerous.";
            IsArmoured = false;

        }//end default dragon

        //methods

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsArmoured)
            {
                calculatedBlock += calculatedBlock / 4;
            }

            return calculatedBlock;

        }//end CalcBlock
    }
}
