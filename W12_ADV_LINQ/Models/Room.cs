namespace W12_ADV_LINQ.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // navigation property
        public virtual ICollection<Character> Characters { get; set; } // one-to-many relationship
    }
}
