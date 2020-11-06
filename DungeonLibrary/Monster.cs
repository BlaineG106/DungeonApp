using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        //properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }//end set
        }//end MinDamage

        //CTORS
        public Monster()
        {

        }
        public Monster(string name, int life, int maxLife, int minDamage, int block, int hitChance, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Life = life;
            Block = block;
            HitChance = hitChance;
            MinDamage = minDamage;
            Description = description;
            Name = name;
        }//end FQCTOR

        //Methods
        public override string ToString()
        {
            return string.Format("\n-=-= Monster =-=-\n" +
                "{0}\n" +
                "Life: {1} of {2}\n" +
                "Damage: {3} to {4}\n" +
                "Hit Chance: {5}\n" +
                "Block: {6}\n" +
                "Description: {7}",
                Name, Life, MaxLife, MinDamage, MaxDamage, HitChance, Block, Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }

    }//end class
}//end namespace
