namespace W6_ABSTRACT.Models
{
    public class Dragon : Monster, IFireBreather
    {
        public string FireType { get;set; }

        public void BreatheFire()
        {
            Console.WriteLine($"{Name} breathes {FireType}!");
        }

        public override void Defend()
        {
            Console.WriteLine($"{Name} defends with its scales!");
        }
    }
}
