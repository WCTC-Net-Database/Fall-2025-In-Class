using System.Security.Cryptography.X509Certificates;
using W6_ABSTRACT.Models;

public static class Program
{
    public static void Main()
    {
        // cannot create an instance of an abstract class
        //var monster = new Monster
        //{
        //    Name = "Generic Monster",
        //    Health = 20
        //};

        var goblin = new Goblin
        {
            Name = "Goblin",
            Health = 30,
            Gold = 10
        };

        var troll = new Troll
        {
            Name = "Troll",
            Health = 50,
            Resistance = "Fire"
        };

        var dragon = new Dragon
        {
            Name = "Dragon",
            Health = 100,
            FireType = "Fire Breath"
        };

        StartBattle(dragon, troll);


    }

    public static void StartBattle(Monster attacker, Monster defender)
    {
        
        if (attacker is IFireBreather firebreather)
        {
            firebreather.BreatheFire();
        }
        else
            attacker.Attack();

        defender.Defend();
    }

}