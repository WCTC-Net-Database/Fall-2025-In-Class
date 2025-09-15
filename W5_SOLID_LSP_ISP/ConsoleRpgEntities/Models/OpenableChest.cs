namespace ConsoleRpgEntities.Models;

public class OpenableChest : ChestBase
{
    public OpenableChest() : base() { }

    public override void Open()
    {
        base.Open();
        Console.WriteLine("The simple chest is now open.");
    }
}
