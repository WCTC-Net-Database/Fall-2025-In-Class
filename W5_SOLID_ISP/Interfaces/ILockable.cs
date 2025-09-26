namespace W5_SOLID_ISP.Interfaces
{
    public interface ILockable
    {
        int KeyId { get; set; }
        bool IsLocked { get; set; }
        void Lock();
        void Unlock();
    }
}