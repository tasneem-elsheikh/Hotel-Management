//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Hotel_Management_System
//{
//    internal class Checking : Reservation
//    {
//        //CheckIn Variables
//        /*--------------------------------------------------------------------------------------------------------*/

//        //Date
//        protected int Day;
//        protected int Month;
//        protected int Year1;

//        //Time
//        protected int Hour;
//        protected int Minute;

//        protected int Days_number;


//        /*--------------------------------------------------------------------------------------------------------*/

//        //Properties
//        public int day
//        {
//            get { return Day; }
//            set { Day = value; }
//        }

//        public int month
//        {
//            get { return Month; }
//            set { Month = value; }
//        }

//        public int year1
//        {
//            get { return year1; }
//            set { year1 = value; }
//        }

//        public int hour
//        {
//            get { return hour; }
//            set { hour = value; }
//        }

//        public int minute
//        {
//            get { return Minute; }
//            set { Minute = value; }
//        }

//        // Property of Number of Days
//        public int Number_of_Days
//        {
//            get { return Days_number; }
//            set { Days_number = value; }
//        }

//        /*--------------------------------------------------------------------------------------------------------*/



//        DBAccess Db = new DBAccess();
//        public void CheckIn(int Day, int Month, int Year, int Hour, int Minute)
//        {
//            //this.Day = Day;
//            //this.Month = Month;
//            //this.Year1 = Year;
//            //this.Hour = Hour;
//            //this.Minute = Minute;


//            Db.CheckIn(Day, Month, Year, Hour, Minute);
//        }

//        public void CheckIn123(int Year)
//        {
//            DateTime CheckIn1 = DateTime.Now;
//            DateTime CheckIn2 = new DateTime();

//        }

//        public void CheckIn123(int Year, int Days)
//        {
//            DateTime CheckIn1 = DateTime.Now;


//        }


//        /*--------------------------------------------------------------------------------------------------------*/





//    }
//}
