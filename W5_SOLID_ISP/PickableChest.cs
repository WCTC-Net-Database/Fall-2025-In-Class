using W5_SOLID_ISP.Interfaces;

namespace ConsoleRpgEntities
{
    // Pickable and lockable chest
    public class PickableChest : IChest, IOpenable, IPickable, ILockable
    {
        public int KeyId { get; set; }
        public bool IsLocked { get; set; }
        public bool IsOpen { get; private set; }
        public bool IsPicked { get; private set; }

        public PickableChest(int keyId, bool isLocked = true)
        {
            KeyId = keyId;
            IsLocked = isLocked;
            IsOpen = false;
            IsPicked = false;
        }

        public void Open()
        {
            if (IsLocked)
                throw new InvalidOperationException("Chest is locked.");
            if (IsOpen)
                throw new InvalidOperationException("Chest is already open.");
            IsOpen = true;
            Console.WriteLine("The pickable chest is now open.");
        }

        public void Pick()
        {
            if (!IsLocked)
                throw new InvalidOperationException("Chest is already unlocked.");
            IsLocked = false;
            IsPicked = true;
            Console.WriteLine("The pickable chest lock has been picked.");
        }

        public void Lock()
        {
            if (IsOpen)
                throw new InvalidOperationException("Cannot lock an open chest.");
            if (IsLocked)
                throw new InvalidOperationException("Chest is already locked.");
            IsLocked = true;
            Console.WriteLine("The pickable chest is now locked.");
        }

        public void Unlock()
        {
            if (!IsLocked)
                throw new InvalidOperationException("Chest is already unlocked.");
            IsLocked = false;
            Console.WriteLine("The pickable chest is now unlocked.");
        }
    }
}