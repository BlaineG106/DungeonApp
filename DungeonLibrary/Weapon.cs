using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private int _minDamage;
        //properties
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public bool IncreaseBlocking { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //CTOR
        public Weapon(string name, int minDamage, int maxDamage, bool increaseBlocking)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IncreaseBlocking = increaseBlocking;
        }//end FQCTOR

        public Weapon()
        {

        }//end default CTOR

        //Method
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\n Weapon Ability: {3}", Name, MinDamage, MaxDamage,

                IncreaseBlocking ? "Increased Blocking" : "Increased Damage");
        }//end ToString()
    }//end class
}//end namespace
