using System;
using System.Linq;
using System.Collections.Generic;
using TheSlum;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Healer : Character, IHeal
    {
        private int healingPoints;

        public Healer(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int healingPoints)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            set
            {
                this.healingPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character leastHealthTarget = targetsList.OrderBy(x => x.HealthPoints).First(x => !x.Equals(this));
            return leastHealthTarget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Healing: {0}", this.healingPoints);
        }
    }
}
