using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Goblin : Monster
    {
        //fields
       
        //properties
        public bool SpearGoblin { get; set; }

        //CTOR
        public Goblin(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool spearGoblin):base(name, life, maxLife, minDamage, hitChance, block, maxDamage, description)
        {
            SpearGoblin = spearGoblin;
        }//end FQCTOR

        public Goblin()
        {
            MaxLife = 6;
            MaxDamage = 4;
            Name = "Dagger Goblin";
            Life = 6;
            HitChance = 30;
            Block = 30;
            MinDamage = 1;
            Description = "A large goblin wielding a sharp dagger capable of piercing even the thickest of armor.";
        }

        //methods
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (SpearGoblin)
            {
                calculatedBlock -= calculatedBlock / 4;
            }

            return calculatedBlock;

        }//end CalcBlock
    }
}
