using System;
using System.Threading;
using System.Threading.Tasks;

namespace Problem02AsynchronousTimer
{
    public class AsyncTimer
    {
        private Action<string> action;
        private int interval;
        private int ticks;

        public AsyncTimer(Action<string> action, int interval, int ticks)
        {
            this.Interval = interval;
            this.Ticks = ticks;
            this.action = action;
            this.OnRun(EventArgs.Empty);
         }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Time interval between each tick cannot be negative!");
                }

                this.interval = value;
            }
        }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of times the method should be called cannot be negative!");
                }

                this.ticks = value;
            }
        }

        public virtual void OnRun(EventArgs e)
        {
            if (this.action != null)
            {
                Thread thread = new Thread(delegate()
                {
                    while (this.Ticks > 0)
                    {
                        this.action("");
                        this.Ticks--;
                        Thread.Sleep(this.Interval);
                    }
                });
                thread.Start();
            }
        }
    }
}
