using ConsoleRpgEntities.Interfaces;

namespace ConsoleRpgEntities.Models;

public class SmallMonster : IMonster
{
    public string Name { get; set; }
    public int Health { get; set; }

    public SmallMonster(string name, int health)
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
        return 5;
    }
}
