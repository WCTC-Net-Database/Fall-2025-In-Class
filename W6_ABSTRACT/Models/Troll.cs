namespace W6_ABSTRACT.Models
{
    public class Troll : Monster
    {
        public string Resistance { get; set; }

        public override void Defend()
        {
            Console.WriteLine($"{Name} defends with {Resistance} resistance!");
        }
    }
}
