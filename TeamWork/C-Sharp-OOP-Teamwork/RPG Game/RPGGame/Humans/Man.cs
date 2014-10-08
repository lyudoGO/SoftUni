namespace RPGGame.Humans
{
    using System.Collections.Generic;

    public class Man : Human
    {
        public Man(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Man";
            this.HealthPoints = 50;
            this.DefensePoints = 0;
            this.Range = 0;
            this.Inventory = new List<Item>(1);
        }

        public override void AddToInventory(Item item)
        {
            if (this.Inventory.Count == 0)
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
