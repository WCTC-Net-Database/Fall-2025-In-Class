namespace ConsoleRpgEntities.Models;

public abstract class ChestBase : IChest, IOpenable
{
    public bool IsOpen { get; protected set; }

    protected ChestBase()
    {
        IsOpen = false;
    }

    public virtual void Open()
    {
        if (IsOpen)
            throw new InvalidOperationException("Chest is already open.");
        IsOpen = true;
        Console.WriteLine("The chest is now open.");
    }
}
