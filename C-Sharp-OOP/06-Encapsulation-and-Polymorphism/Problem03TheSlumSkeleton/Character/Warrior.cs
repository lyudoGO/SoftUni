using System;
using System.Linq;
using System.Collections.Generic;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Warrior : Character, IAttack
    {
        private int attackPoints;

        public Warrior(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int attackPoints)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character firstTarget = targetsList.FirstOrDefault(x => (x.IsAlive && x.Team != this.Team));
            return firstTarget;
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
            return base.ToString() + string.Format(", Attack: {0}", this.attackPoints);
        }
    }
}
