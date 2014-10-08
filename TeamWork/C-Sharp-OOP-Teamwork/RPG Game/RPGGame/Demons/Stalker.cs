namespace RPGGame.Demons
{
    public class Stalker : Demon
    {
        public Stalker(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Stalker";
            this.HealthPoints = 50;
            this.DefensePoints = 50;
            this.Range = 10;
        }
    }
}
