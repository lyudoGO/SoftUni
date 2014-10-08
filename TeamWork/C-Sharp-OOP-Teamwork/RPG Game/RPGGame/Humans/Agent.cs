namespace RPGGame.Humans
{
    using System.Collections.Generic;

    public class Agent : Human
    {
        public Agent(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Agent";
            this.HealthPoints = 90;
            this.DefensePoints = 50;
            this.Range = 5;
            this.Inventory = new List<Item>(4); 
        }

        public override void AddToInventory(Item item)
        {
            if (this.Inventory.Count < 4)
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
