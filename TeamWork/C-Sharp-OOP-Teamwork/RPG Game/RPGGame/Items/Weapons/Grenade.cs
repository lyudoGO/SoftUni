namespace RPGGame.Items.Weapons
{
    public class Grenade : Weapon
    {
        public Grenade(string id, double range, DestructiveForce force)
            : base(id, range, force)
        {
            this.id = "Grenade";
            this.Range = 20;
            force = DestructiveForce.Middle;
        }

    }
}
