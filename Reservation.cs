using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    
     class Reservation
    {
        protected string firstname;
        protected string secondname;
        protected string phone_number;
        protected int id;
        protected int room_number;
        protected bool occupancy;
        protected string roomtype;
        

        

        // Creating Properties
        /*--------------------------------------------------------------------------------*/

        public int Id 
        { 
            get { return id; }
            set { id = value; } 
        }

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
            {
                if (value.Length == 11) //Cheacking the Length of the Phone Number is correct
                    phone_number = value;
            }

        }

        public int RoomNumber
        {
            get { return room_number; }
            set
            {
                if (value > 0 || value < 1000)
                    room_number = value;
            }
        }

        public bool Occupancy
        {
            get => occupancy;
            set
            {
                occupancy = value;
            }
        }

        public string RoomType
        {
            get { return roomtype; }
            set
            {
                if (value == "Single" || value == "Double" || value == "King" || value == "Suite")
                {
                    roomtype = value;
                }
            }
        }

        /*--------------------------------------------------------------------------------*/



        //Inserting the data into the database
        /*--------------------------------------------------------------------------------------------------------*/

        DBAccess dbAccess = new DBAccess();
        public void BookRoom(string firstName, string lastName, string phoneNumber, int roomNumber, int id)
        {
            dbAccess.InsertCustomerInfo(firstname, secondname, phone_number, room_number, id);
        }

        /*--------------------------------------------------------------------------------------------------------*/





        //Constructors
        /*--------------------------------------------------------------------------------------------------------*/

        public Reservation(string firstname, string secondname, string phone_number, int room_number, string roomtype)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.phone_number = phone_number;
            this.room_number = room_number;
            this.roomtype = roomtype;
        }

        //Default Constructor
        public Reservation()
        { }

        /*--------------------------------------------------------------------------------------------------------*/


        //A Method to Read the ClientInfo
        public void InsertGuestInfo()
        {
            Console.WriteLine("Please enter the Guest's first name then second name:");
            firstname = Console.ReadLine();
            secondname = Console.ReadLine();

            Console.WriteLine("Please enter the Guest's phone number and make sue they consist of 11 digits");
            phone_number = Console.ReadLine();

            Console.WriteLine("Enter the Guest's Id: ");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Guest's Room Type");
            roomtype = Console.ReadLine();
        }


        public string GetVacancy()
        {
            Console.WriteLine("Enter the room type the customer desires, whether Single, Double, King or Suite:");
            roomtype = Console.ReadLine();

            if (roomtype == "Single")
            {
                while (0 < room_number && room_number <= 500)
                {
                    int counter = 0;
                    counter++;

                    if (occupancy == false)
                    {
                        room_number = counter;
                        return $"{this.room_number}is vaccant";
                    }

                }

                return "all rooms of this roomtype are occupied";
            }


            else if (roomtype == "Double")
            {
                while (500 < room_number && room_number <= 800)
                {
                    int counter = 500;
                    counter++;

                    if (occupancy == false)
                    {

                        room_number = counter;
                        return $"{this.room_number}is vaccant";
                    }

                }
                return $"all rooms of this roomtype are occupied";
            }


            else if (roomtype == "King")
            {
                while (800 < room_number && room_number <= 950)
                {
                    int counter = 800;
                    counter++;
                    if (occupancy == false)
                    {

                        room_number = counter;
                        return $"{this.room_number}is vaccant";
                    }

                }
                return $"all rooms of this roomtype are occupied";
            }


            else if (roomtype == "Suite")
            {
                while (950 < room_number && room_number <= 1000)
                {
                    int counter = 950;
                    counter++;
                    if (occupancy == false)
                    {
                        room_number = counter;
                        return $"{this.room_number}is vaccant";
                    }

                }
                return $"all rooms of this type are occupied";
            }


            return "Error";
        }









        //Check-In and Check-Out Implementation
        protected int Days_number;

        // Property of Number of Days
        public int Number_of_Days
        {
            get { return Days_number; }
            set { Days_number = value; }
        }

        //Date
        protected int Day;
        protected int Month;
        protected int Year;

        //Time
        protected int Hour;
        protected int Minute;

        


        


    }//End of Class
}//End of Program