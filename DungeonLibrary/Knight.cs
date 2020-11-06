using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Knight : Monster
    {
        //fields
        

        //properties
        public bool CanLeap { get; set; }

        //CTORS
        public Knight(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool canLeap):base(name, life, maxLife, minDamage, block, hitChance, maxDamage, description)
        {
            CanLeap = canLeap;
        }//end FQCTOR

        public Knight()
        {
            MaxLife = 10;
            MaxDamage = 8;
            Life = 10;
            MinDamage = 4;
            HitChance = 30;
            Block = 20;
            Name = "Skeleton Knight";
            Description = "This knight from beyond the grave rises from the ground wielding a large sword and full armor";
            CanLeap = false;
        }//end default knight

        //methods
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (CanLeap)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }//end CalcBlock
    }
}
