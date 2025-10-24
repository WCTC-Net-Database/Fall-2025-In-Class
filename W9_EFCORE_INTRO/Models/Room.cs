namespace W9_EFCORE_INTRO.Models
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
