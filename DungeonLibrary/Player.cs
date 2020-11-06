using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //properties
        public Race CharacterType { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //CTOR
        public Player(string name, int maxLife, int life, int block, int hitChance, Race characterType, Weapon equippedWeapon)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            Block = block;
            HitChance = hitChance;
            CharacterType = characterType;
            EquippedWeapon = equippedWeapon;
        }//end fqctor

        public Player()
        {

        }//end default ctor

        //methods
        public override string ToString()
        {
            return string.Format("**** {0} ****\n" +
                "Life: {1} of {2}\n" +
                "Weapon: {3}\n" +
                "Hit Chance: {4}\n" +
                "Block: {5}\n",
                Name, Life, MaxLife, EquippedWeapon, HitChance, Block);
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage);

            return damage;
        }
    }//end class
}//end namespace
