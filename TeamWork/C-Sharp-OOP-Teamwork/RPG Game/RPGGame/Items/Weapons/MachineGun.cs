namespace RPGGame.Items.Weapons
{
    public class MachineGun : Weapon
    {
        public MachineGun(string id, double range, DestructiveForce force)
            : base(id, range, force)
        {
            this.id = "Machine Gun";
            this.Range = 40;
            force = DestructiveForce.Middle;
        }
    }
}
