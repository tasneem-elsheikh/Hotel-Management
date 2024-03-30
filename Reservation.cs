using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    internal class Reservation
    {
        protected string firstname;
        protected string secondname;
        protected string phone_number;
        protected int room_number;
        protected bool occupancy;
        //protected List<Reservation> reservations;

        // Creating Properties
 /*--------------------------------------------------------------------------------*/   
        
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string SecondName
        {
            get { return secondname; }
            set { secondname = value; }
        }

        public string PhoneNumber
        {
            get { return phone_number; }

            set
            {    if(value.Length == 11) //Cheacking the Length of the Phone Number ic correct
                    phone_number = value;
            }

        }

        public int RoomNumber
        {
            get { return room_number; }
            set
            {   if (value > 0 || value < 1000)
                    room_number = value;
            }
        }

        public bool Occupancy
        {
            get { return occupancy; }
            set { occupancy = value; }
        }


    }//End of Class

}// End of Program
