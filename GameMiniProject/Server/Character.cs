using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameMiniProject
{
    public enum CharClass { Warrior, Thief }
    public class Character : GameObject
    {

        public string name;
        public CharClass charClass;



        public Character(string name, CharClass charc,double locX,double locY, double spd) : base(locX, locY, spd)
        { 
            name = this.name;
            charClass = charc;
            Location.X = Convert.ToDouble(locX);
            Location.Y = Convert.ToDouble(locY);
            TargetSpeed = spd;
        }
    }
}

