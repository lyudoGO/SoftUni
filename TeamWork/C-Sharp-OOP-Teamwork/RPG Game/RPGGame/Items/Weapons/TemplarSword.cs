namespace RPGGame.Items.Weapons
{
    public class TemplarSword : Weapon
    {
        public TemplarSword(string id, double range, DestructiveForce force)
            : base(id, range, force)
        {
            this.id = "Templar Sword";
            this.Range = 5;
            force = DestructiveForce.Large;
        }
    }
}
