namespace RPGGame.Demons
{
    using System.Collections.Generic;

    public class TheProwler : Demon
    {
        public TheProwler(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "The Prowler";
            this.HealthPoints = 60;
            this.DefensePoints = 30;
            this.Range = 20;
            this.Inventory = new List<Item>(2);
        }

        public override void AddToInventory(Item item)
        {
            if (this.Inventory.Count < 2)
            {
                this.Inventory.Add(item);
            }
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}
