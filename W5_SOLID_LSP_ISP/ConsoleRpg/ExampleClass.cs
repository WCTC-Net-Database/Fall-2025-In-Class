using ConsoleRpgEntities.Interfaces;
using ConsoleRpgEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpgEntities
{
    // --- INTERFACES ---

    // ISP: Interfaces are small and focused
    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        void TakeDamage(int amount);
        int DealDamage();
    }

    public interface IThief : IMonster
    {
        void Steal();
    }

    public interface IOpenable
    {
        void Open();
    }

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

    public interface IChest { }

    // --- ENTITIES ---

    // SRP: Each class has a single responsibility

    public class SmallMonster : IMonster
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public SmallMonster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public int DealDamage()
        {
            return 5; // Example fixed damage
        }
    }

    public class ThiefMonster : IThief
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public ThiefMonster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public int DealDamage()
        {
            return 7; // Example fixed damage
        }

        public void Steal()
        {
            // Example steal logic
            Console.WriteLine($"{Name} steals an item!");
        }
    }

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

    // --- TESTING/USAGE ---

    public class Testing
    {
        public void Main()
        {
            IMonster monster = new SmallMonster("Goblin", 30);
            IThief thief = new ThiefMonster("Bandit", 40);
            Player player = new Player("Hero", "Wizard", 15, 5, new List<string>());

            monster.DealDamage();
            thief.Steal();

            // Demonstrate a simple openable chest
            OpenableChest openableChest = new OpenableChest();
            Console.WriteLine("Attempting to open a simple chest...");
            openableChest.Open();

            // Demonstrate a pickable chest
            PickableChest pickableChest = new PickableChest(keyId: 1, isLocked: true);
            Console.WriteLine("Attempting to open a locked pickable chest...");
            try
            {
                pickableChest.Open();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Cannot open: {ex.Message}");
            }

            Console.WriteLine("Attempting to pick the lock...");
            pickableChest.Pick();

            Console.WriteLine("Attempting to open the chest after picking...");
            pickableChest.Open();
        }
    }
}
