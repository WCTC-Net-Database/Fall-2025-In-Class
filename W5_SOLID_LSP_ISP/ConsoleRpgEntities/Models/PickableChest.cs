namespace ConsoleRpgEntities.Models;

public class PickableChest : LockableChestBase, IPickable
{
    public bool IsPicked { get; private set; }

    public PickableChest(int keyId, bool isLocked = true) : base(keyId, isLocked)
    {
        IsPicked = false;
    }

    public void Pick()
    {
        if (!IsLocked)
            throw new InvalidOperationException("Chest is already unlocked.");
        IsLocked = false;
        IsPicked = true;
        Console.WriteLine("The pickable chest lock has been picked.");
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine("The pickable chest is now open.");
    }
}
