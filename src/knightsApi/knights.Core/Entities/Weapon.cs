namespace Knights.Core.Entities
{
    public class Weapon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Mod { get; set; }
        public string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}