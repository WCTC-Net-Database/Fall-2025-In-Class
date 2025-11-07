using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace W11_EFCORE_ABSTRACT.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        // navigation properties
        public virtual Weapon? Weapon { get; set; }
        public virtual Armor? Armor { get; set; }

        override public string ToString()
        {
            return $"Equipment(Id={Id}, Weapon={Weapon}, Armor={Armor})";
        }

        public void EquipWeapon(Weapon weapon)
        {

            Weapon = weapon;
        }

        public void EquipArmor(Armor armor)
        {
                Armor = armor;
        }
        //public void TryEquip(Item item)
        //{
        //    if (item is Weapon)
        //    {
        //        EquipWeapon(item);
        //    }
        //    else if (item is Armor)
        //    {
        //        EquipArmor(item);
        //    }
        //}
    }

}
