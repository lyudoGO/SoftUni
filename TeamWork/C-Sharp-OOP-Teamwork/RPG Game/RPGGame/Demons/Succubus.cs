namespace RPGGame.Demons
{
    using RPGGame.Interfaces;

    public class Succubus : Demon, IFlyable
    {
        public Succubus(string id, int healthPoints, int defensePoints, double range)
            : base(id, healthPoints, defensePoints, range)
        {
            this.id = "Succubus";
            this.HealthPoints = 100;
            this.DefensePoints = 70;
            this.Range = 30;
        }
    }
}
