namespace RPGGame.Items
{
    public class Weapon : Item
    {
        public Weapon(string id, double range, DestructiveForce force)
            : base(id)
        {
            this.Range = range;
        }

        public double Range { get; set; }
    }
}
