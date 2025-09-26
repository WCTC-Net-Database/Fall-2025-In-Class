using W5_SOLID_ISP.Interfaces;

namespace ConsoleRpgEntities
{
    public class ThiefMonster : IThief
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public ThiefMonster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public int DealDamage()
        {
            return 7; // Example fixed damage
        }

        public void Steal()
        {
            // Example steal logic
            Console.WriteLine($"{Name} steals an item!");
        }
    }
}