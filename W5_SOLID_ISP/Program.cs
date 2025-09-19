
namespace W5_SOLID_ISP;
public class Program
{
    public static void Main()
    {
        IMonster monster = new SmallMonster("Goblin", 30);
        IThief thief = new ThiefMonster("Bandit", 40);
        Player player = new Player("Hero Bob", "Knight", 15, 5, new List<string>());

        thief.Steal(player);
        monster.Attack(player, 5);

        Console.WriteLine("----------------------");
        
        IOpenable chest = new OpenableChest();
        chest.Open();
        chest.Open();

        chest.Close();

        Console.WriteLine("----------------------");

        // if randomly generating chests, we could have something like this:
        IChest pickableChest = new PickableChest(keyId: 1);

        if (pickableChest is IOpenable openableChest)
        {
            openableChest.Open();
        }

        if (pickableChest is IPickable pickable)
        {
            pickable.Pick();
        }

        if (pickableChest is IOpenable openableChest1)
        {
            openableChest1.Open();
        }

    }
}

// marker interface
public interface IChest { }

public interface IPickable
{
    void Pick();
}
public interface ILockable
{
    int KeyId { get; set; }
    bool IsLocked { get; set; }
    void Lock();
    void Unlock();
}
public interface IOpenable
{
    bool IsOpen { get; set; }
    void Open();
    void Close();
}
public interface IDamageable
{
    void Damage();
}

public class OpenableChest : IOpenable, IChest
{
    public bool IsOpen { get; set; }

    public void Close()
    {
        if (IsOpen)
        {
            IsOpen = false;
            Console.WriteLine("The chest is now closed");
        }
        else
        {
            Console.WriteLine("The chest is already closed");
        }
    }

    public void Open()
    {
        if (IsOpen)
        {
            Console.WriteLine("The chest is already open");
        }
        else
        {
            IsOpen = true;
            Console.WriteLine("The chest is now open");
        }
    }
}

public class PickableChest : IPickable, ILockable, IOpenable, IChest
{
    public int KeyId { get; set; }
    public bool IsLocked { get; set; }
    public bool IsOpen { get; set; }

    public PickableChest(int keyId, bool isLocked = true)
    {
        KeyId = keyId;
        IsLocked = isLocked;
        IsOpen = false;
    }

    public void Lock()
    {
        if (IsOpen)
        {
            Console.WriteLine("Cannot lock the chest while it is open.");
            return;
        }
        if (IsLocked)
        {
            Console.WriteLine("The chest is already locked.");
        }
        else
        {
            IsLocked = true;
            Console.WriteLine("The chest is now locked.");
        }
    }

    public void Unlock()
    {
        if (!IsLocked)
        {
            Console.WriteLine("The chest is already unlocked.");
        }
        else
        {
            IsLocked = false;
            Console.WriteLine("The chest is now unlocked.");
        }
    }

    public void Open()
    {
        if (IsOpen)
        {
            Console.WriteLine("The chest is already open.");
        }
        else if (IsLocked)
        {
            Console.WriteLine("The chest is locked. You need to unlock or pick it first.");
        }
        else
        {
            IsOpen = true;
            Console.WriteLine("The chest is now open.");
        }
    }

    public void Close()
    {
        if (!IsOpen)
        {
            Console.WriteLine("The chest is already closed.");
        }
        else
        {
            IsOpen = false;
            Console.WriteLine("The chest is now closed.");
        }
    }

    public void Pick()
    {
        if (!IsLocked)
        {
            Console.WriteLine("The chest is already unlocked.");
        }
        else
        {
            IsLocked = false;
            Console.WriteLine("You picked the lock! The chest is now unlocked.");
        }
    }
}
public class Player
{
    public Player(string v1, string v2, int v3, int v4, List<string> list)
    {
        Name = v1;
        Profession = v2;
        HitPoints = v3;
        Level = v4;
        Equipment = list;
    }

    public string Name { get; set; }
    public string Profession { get; set; }
    public int HitPoints { get; set; }
    public int Level { get; set; }
    public List<string> Equipment { get; set; }

    public void TakeDamage(int damageAmount)
    {
        HitPoints -= damageAmount;
        Console.WriteLine($"{Name} takes {damageAmount} damage! He has {HitPoints} remaining!");
    }
}

public class SmallMonster : IMonster
{
    public SmallMonster(string name, int hitpoints)
    {
        Name = name;
        HitPoints = hitpoints;
    }

    public string Name { get; }
    public int HitPoints { get; }

    public void Attack(Player player, int damageAmount)
    {
        Console.WriteLine($"Monster {Name} attacks {player.Name}!");
        player.TakeDamage(damageAmount);
    }
}

public class ThiefMonster : IMonster, IThief
{
    public ThiefMonster(string name, int hitpoints)
    {
        Name = name;
        HitPoints = hitpoints;
    }

    public string Name { get; }
    public int HitPoints { get; }
    public void Attack(Player player, int damageAmount)
    {
        Console.WriteLine($"Monster {Name} leaps through the air and attacks {player.Name}!");
        player.TakeDamage(damageAmount);
    }
    public void Steal(Player player)
    {
        Console.WriteLine($"Monster {Name} steals from {player.Name}!");
    }
}

public interface IMonster
{
    void Attack(Player player, int damageAmount);
}

public interface IThief
{
    void Steal(Player player);
}
