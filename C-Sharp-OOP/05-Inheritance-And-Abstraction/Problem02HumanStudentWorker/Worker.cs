using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02HumanStudentWorker
{
    class Worker : Human
    {
        private const int WorkingDays = 5;
      
        private decimal weekSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary 
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public float WorkHoursPerDay 
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = (this.weekSalary / (WorkingDays * (decimal)this.workHoursPerDay));
            return moneyPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Week salary: {0}LV; Works on day: {1}h", this.WeekSalary, this.WorkHoursPerDay);
        }

    }
}