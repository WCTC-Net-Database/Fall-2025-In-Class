namespace ConsoleRpgEntities.Models;

public abstract class LockableChestBase : ChestBase, ILockable
{
    public int KeyId { get; set; }
    public bool IsLocked { get; set; }

    protected LockableChestBase(int keyId, bool isLocked = true) : base()
    {
        KeyId = keyId;
        IsLocked = isLocked;
    }

    public override void Open()
    {
        if (IsLocked)
            throw new InvalidOperationException("Chest is locked.");
        base.Open();
    }

    public virtual void Lock()
    {
        if (IsOpen)
            throw new InvalidOperationException("Cannot lock an open chest.");
        if (IsLocked)
            throw new InvalidOperationException("Chest is already locked.");
        IsLocked = true;
        Console.WriteLine("The chest is now locked.");
    }

    public virtual void Unlock()
    {
        if (!IsLocked)
            throw new InvalidOperationException("Chest is already unlocked.");
        IsLocked = false;
        Console.WriteLine("The chest is now unlocked.");
    }
}
