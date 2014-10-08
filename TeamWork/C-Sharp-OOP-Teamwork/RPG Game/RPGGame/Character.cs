namespace RPGGame
{
    using System.Collections.Generic;

    public abstract class Character : GameObject
    {
        protected Character(string id, int healthPoints, int defensePoints, double range)
            : base(id)
        {
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.IsAlive = true;
            this.Range = range;
            this.Inventory = new List<Item>();
        }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public bool IsAlive { get; set; }

        public double Range { get; set; }

        public List<Item> Inventory { get; set; }

        public abstract void AddToInventory(Item item);

        public abstract void RemoveFromInventory(Item item);



    }
}
