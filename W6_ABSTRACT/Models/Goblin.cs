namespace W6_ABSTRACT.Models
{
    public class Goblin : Monster
    {
        public int Gold { get; set; }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks and drops {Gold} gold!");
        }

        public override void Defend()
        {
            Console.WriteLine($"{Name} defends by dancing out the way!");
       }

    }
}
