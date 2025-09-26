using W5_SOLID_ISP.Interfaces;

namespace ConsoleRpgEntities
{
    // --- CHEST IMPLEMENTATIONS ---

    // Simple openable chest (no lock, no pick)
    public class OpenableChest : IChest, IOpenable
    {
        public bool IsOpen { get; private set; }

        public OpenableChest()
        {
            IsOpen = false;
        }

        public void Open()
        {
            if (IsOpen)
                throw new InvalidOperationException("Chest is already open.");
            IsOpen = true;
            Console.WriteLine("The simple chest is now open.");
        }
    }
}