namespace RPGGame.Humans
{
    using System.Collections.Generic;

    public class Templar : Human
    {
        public Templar(string id, int healthPoints, int defensePoints, double range, Item templarSword)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Knight Templar";
            this.HealthPoints = 100;
            this.DefensePoints = 100;
            this.Range = 10;
            this.TemplarSword = templarSword;
            this.Inventory = new List<Item>(5);
        }

        public Item TemplarSword { get; set; }

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
