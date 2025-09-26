namespace W5_SOLID_ISP.Interfaces
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
}