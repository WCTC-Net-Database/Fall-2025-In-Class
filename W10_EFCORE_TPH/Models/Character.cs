namespace W9_EFCORE_INTRO.Models
{
    public class Character
    {
        public int Id { get; set; }         // number
        public string Name { get; set; }    // varchar
        public int Level { get; set; }      // number

        // navigation property
        public virtual Room? Room { get; set; }      // foreign key
    }
}
