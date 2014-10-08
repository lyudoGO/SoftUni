namespace RPGGame.Humans
{
    using System.Collections.Generic;

    public class Sergeant : Human
    {
        public Sergeant(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Sergeant";
            this.HealthPoints = 90;
            this.DefensePoints = 50;
            this.Range = 5;
            this.Inventory = new List<Item>(5);
        }

        public override void AddToInventory(Item item)
        {
            if (this.Inventory.Count < 5)
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
