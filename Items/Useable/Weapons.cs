using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.Items.Abstract;
using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{
    
    public class Weapons : Abstract.Useable
    {
        public string Type;
        protected Weapons(Square square, string name, char mapSymbol, int attack, int armor, string weaponType) : base(
            square, name, mapSymbol, attack, armor)
        {
            Type = weaponType;
        }

        public void WeaponType(string weaponType)
        {
            switch (weaponType)
            {
                case "PooStick":
                    this.Name = "Ultimate weapon - stick with a poo at the en";
                    this.MapSymbol = '\u2694';
                    this.Attack = 500;
                    break;
                case "RustyPan":
                    this.Name = "Slightly rusted pan";
                    this.MapSymbol = '\u2694';
                    this.Attack = 15;
                    break;
                case "Club":
                    this.Name = "Club (Welcome to the club)";
                    this.MapSymbol = '\u2694';
                    this.Attack = 20;
                    break;
                case "ShortSword":
                    this.Name = "Short sword (looks big in small hands)";
                    this.MapSymbol = '\u2694';
                    this.Attack = 30;
                    break;
                case "ShortSAxe":
                    this.Name = "Short axe";
                    this.MapSymbol = '\u2694';
                    this.Attack = 40;
                    break;
                case "LongSword":
                    this.Name = "Loooong sword";
                    this.MapSymbol = '\u2694';
                    this.Attack = 50;
                    break;
                case "LongAxe":
                    this.Name = "Long axe";
                    this.MapSymbol = '\u2694';
                    this.Attack = 60;
                    break;
                case "Hammer":
                    this.Name = "Hammer time";
                    this.MapSymbol = '\u2694';
                    this.Attack = 65;
                    break;
                case "Claymore":
                    this.Name = "Claymore";
                    this.MapSymbol = '\u2694';
                    this.Attack = 70;
                    break;
            }
        }
        

    }
}
