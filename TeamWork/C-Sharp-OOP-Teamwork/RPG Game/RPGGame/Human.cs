namespace RPGGame
{
    public class Human : Character
    {
        public Human(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            
        }



        public override void AddToInventory(Item item)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveFromInventory(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
