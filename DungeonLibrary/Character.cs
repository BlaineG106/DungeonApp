using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //fields
        private int _life;

        //properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end Life

        //methods
        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        public virtual int CalcDamage()
        {
            return 0;
        }//end CalcDamage()
    }
}
