namespace W11_EFCORE_ABSTRACT.Models
{
    public class Character
    {
        public int Id { get; set; }         // number
        public string Name { get; set; }    // varchar
        public int Level { get; set; }      // number


        // navigation property
        public virtual Equipment Equipment { get; set; }
        public virtual List<Item> Items { get; set; }

        public virtual Room? Room { get; set; }      // foreign key

        public void ListEquipment()
        {
            Console.WriteLine($"{Name}'s Equipment:");
            if (Equipment != null)
            {
                Console.WriteLine($"Equipment: {Equipment}");
            }
            else
            {
                Console.WriteLine("No equipment.");
            }
        }
        public void ListItems()
        {
            Console.WriteLine($"{Name}'s Items:");
            if (Items != null && Items.Count > 0)
            {
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("No items.");
            }
        }

        public void AddItem(Item item)
        {
            if (Items == null)
            {
                Items = new List<Item>();
            }
            Items.Add(item);
        }
    }

}
