namespace RPGGame.Items.Weapons
{
    public class GrenadeLauncher : Weapon
    {
        public GrenadeLauncher(string id, double range, DestructiveForce force)
            : base(id, range, force)
        {
            this.id = "Grenade Launcher";
            this.Range = 50;
            force = DestructiveForce.Large;
        }
    }
}
