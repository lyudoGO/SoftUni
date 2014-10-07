namespace TheSlum
{
    using TheSlum.Interfaces;

    class Pill : Bonus, ITimeoutable
    {
        public Pill(string id)
            : base(id, 0, 0, 100)
        {
            this.Countdown = 1;
        }
    }
}