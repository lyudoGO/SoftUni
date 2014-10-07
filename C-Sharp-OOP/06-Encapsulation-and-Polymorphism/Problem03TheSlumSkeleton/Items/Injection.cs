namespace TheSlum
{
    using TheSlum.Interfaces;

    public class Injection : Bonus, ITimeoutable 
    {
        public Injection(string id)
            : base(id, 200, 0, 0)
        {
            this.Countdown = 3;
        }
     }
}