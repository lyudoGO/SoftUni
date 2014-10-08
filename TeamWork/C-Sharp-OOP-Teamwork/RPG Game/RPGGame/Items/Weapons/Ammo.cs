namespace RPGGame.Items.Weapons
{
    // This means that increase ammunition of current weapon
    public class Ammo : Item
    {
         public Ammo(string id)
            : base(id)
        {
            this.id = "Ammo";
        }
    }
}
