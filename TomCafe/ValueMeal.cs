using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomCafe
{
    class ValueMeal:Product
    {
        //Create properties
        private DateTime startTime;
        private DateTime endTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        //Create constructors
        public ValueMeal() { }

        public ValueMeal(string n, double p, DateTime st, DateTime et):base(n,p)
        {
            StartTime = st;
            EndTime = et;
        }

        //Create methodss
        public override double GetPrice()
        {
            return Price;
        }

        public bool IsAvailable()
        {
            if (DateTime.Now.TimeOfDay >= StartTime.TimeOfDay && DateTime.Now.TimeOfDay <= EndTime.TimeOfDay)
                return true;

            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }


    }
}
