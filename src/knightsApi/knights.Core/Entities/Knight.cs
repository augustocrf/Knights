using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Knights.Core.Entities
{
    public class Knight
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }    
        public string HeroClass { get; set; } // e.g., "Warrior", "Mage"
        public List<Power> Powers { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Attributes Attribute { get; set; } // e.g., {"Strength": 10, "Agility": 8}
        public int Age { get; set; }
        public int Attack { get; set; }
        public int Exp { get; set; }    
        public string keyAttribute { get; set; }        
    }
}