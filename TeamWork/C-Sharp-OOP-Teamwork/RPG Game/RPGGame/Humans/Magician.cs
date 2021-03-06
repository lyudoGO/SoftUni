﻿namespace RPGGame.Humans
{
    using System.Collections.Generic;

    public class Magician : Human
    {
        public Magician(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Magician";
            this.HealthPoints = 100;
            this.DefensePoints = 90;
            this.Range = 30;
            this.Inventory = new List<Item>(3);
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
