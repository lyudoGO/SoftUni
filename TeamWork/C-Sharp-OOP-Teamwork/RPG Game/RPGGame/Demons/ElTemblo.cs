namespace RPGGame.Demons
{
    using System.Collections.Generic;

    public class ElTemblo : Demon
    {
        public ElTemblo(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "El Temblo";
            this.HealthPoints = 70;
            this.DefensePoints = 50;
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
