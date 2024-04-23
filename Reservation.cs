using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace Hotel_Management_System
{
    
     class Reservation
    {
        protected string firstname;
        protected string lastName;
        protected string phone_number;
        protected string id;
        protected int room_number;
        protected bool occupancy;
        protected string roomtype;
        

        

        // Creating Properties
        /*--------------------------------------------------------------------------------*/

        public string Id 
        { 
            get { return id; }
            set { 
                if(value.Length == 14) // Checking the length of the national id
                {
                    id = value;
                }
                }
            }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
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
                if (value == "Single" || value == "Double"|| value == "Suite")
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
            dbAccess.InsertCustomerInfo(firstname,lastName, phone_number, room_number, id); ;
        }

        /*--------------------------------------------------------------------------------------------------------*/





        //Constructors
        /*--------------------------------------------------------------------------------------------------------*/

        public Reservation( string firstname, string lastName, string phone_number, string id, int room_number,bool occupancy, string roomtype )
        {
            this.firstname = firstname;
            this.lastName = lastName;
            this.phone_number = phone_number;
            this.id = id;
            this.room_number = room_number;
            this.occupancy = occupancy;
            this.roomtype = roomtype;
        }

        //Default Constructor
        public Reservation()
        { }

        /*--------------------------------------------------------------------------------------------------------*/


        //A Method to Read the ClientInfo
        //A Method to Read the ClientInfo
        public void InsertGuestInfo()
        {
            Console.WriteLine("Please enter your first name then second name:");
            firstname = Console.ReadLine();

            Console.WriteLine("Please enter your Last Name");
            lastName = Console.ReadLine();

            Console.WriteLine("Please enter your phone number");
            phone_number = Console.ReadLine();

            Console.WriteLine("Enter your Id: ");
            id = Console.ReadLine();


        }

        private bool IsRoomOccupied(int room_number)
        {
            if(occupancy == true)
            {
                // room is empty therefore return false becase room is not occupied
                return false;
            }

            else // the other condition is occupancy == false which indicates that the room is not empty and as a result the program will retutn true as the room is occupied
            {
                return true;
            }
        }

        public string GetVacancy()
        {
            Console.WriteLine("Enter the room type the Guest desires, whether Single, Double or Suite:");
            roomtype = Console.ReadLine();

            int startroomnumber = 0;
            int endroomnumber = 0;
            int i;
            switch (roomtype)
            {
                case "Single":
                    startroomnumber = 1;
                    endroomnumber = 600;
                    break;

                case "Double":
                    startroomnumber = 601;
                    endroomnumber = 900;
                    break;

                case "Suite":
                    startroomnumber = 901;
                    endroomnumber = 1000;
                    break;

                default:
                    return "Invalid room type !!";
            }

            for (i = startroomnumber; i <= endroomnumber; i++)
            {
                if (!IsRoomOccupied(i))
                {
                    return $"Room number {i} is vaccant";
                }

            }
            room_number = i;
            return $" All rooms of type {roomtype} are occupied";
        }

        public void occupyRoom(int room_number)
        {
            if (occupancy == true)
            {
                occupancy = false;
                Console.WriteLine($"Room {room_number} is now booked successfully");
            }

            else
            {
                Console.WriteLine("Failed to book the room");
            }
        }
     }//End of Class
}//End of Program