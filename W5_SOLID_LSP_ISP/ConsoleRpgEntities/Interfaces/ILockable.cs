namespace ConsoleRpgEntities;

public interface ILockable
{
    int KeyId { get; set; }
    bool IsLocked { get; set; }
    void Lock();
    void Unlock();
}
