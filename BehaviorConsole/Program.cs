public class Program
{
    public static void Main()
    {
        ICharacter player = new Player();
        player.Move();
        ICharacter goblin = new Goblin();
        goblin.Move();
        ICharacter ghost = new Ghost();

        if (ghost is IFlyable)
        {
            ((Ghost)ghost).Fly();
        }
    }
}

public class Player : ICharacter
{
    public void Move()
    {
        Console.WriteLine("The player moves");
    }
}

public class Goblin : ICharacter
{
    public void Move()
    {
        Console.WriteLine("The goblin moves");
    }
}

public class Ghost : ICharacter, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("The ghost flies away");
    }

    public void Move()
    {
        Console.WriteLine("The ghost moves towards you");
    }
}

// behavior interface
public interface IFlyable
{
    void Fly();
}
public interface ICharacter
{
    void Move();
}