namespace W11_EFCORE_ABSTRACT.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        // navigation properties
        public virtual Item? Weapon { get; set; }
        public virtual Item? Armor { get; set; }
    }

}
