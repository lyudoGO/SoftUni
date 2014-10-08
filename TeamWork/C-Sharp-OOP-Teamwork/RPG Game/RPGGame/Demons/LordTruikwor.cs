namespace RPGGame.Demons
{
    using System.Collections.Generic;

    public class LordTruikwor : Demon
    {
        public LordTruikwor(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Lord Truikwor";
            this.HealthPoints = 100;
            this.DefensePoints = 100;
            this.Range = 30;
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
