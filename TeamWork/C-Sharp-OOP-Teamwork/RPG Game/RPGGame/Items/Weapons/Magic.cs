namespace RPGGame.Items.Weapons
{
    public class Magic : Weapon
    {
        public Magic(string id, double range, DestructiveForce force)
            : base(id, range, force)
        {
            this.id = "Magic";
            this.Range = 40;
            force = DestructiveForce.Extralarge;
        }
    }
}
