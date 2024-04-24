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
    
     public class Reservation 
    {
        protected string firstname;
        protected string lastName;
        protected string phone_number;
        /*protected*/public  string id;
        protected int room_number;
        protected bool occupancy;
        protected string roomtype;
        public int Price_Per_Night;
        
        

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
        public void BookRoom(string firstName, string lastName, string phoneNumber, int roomNumber, string id)
        {
            dbAccess.InsertGuestInfo(firstName, lastName, phoneNumber, roomNumber, id);

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

        public void DeleteClient(string id)
        {
            dbAccess.DeleteGuestInfo(id);

        }


        //Searching int the client info table and returning values by calling the method inside the database 
        public Reservation SearchCustomerById(string id)
        {
            DBAccess dbAccess1 = new DBAccess();

            try
            {
                return dbAccess1.SearchCustomerById(id);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the search
                Console.WriteLine("An error occurred while searching for the customer: " + ex.Message);
                return null;
            }
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

        public string GetVacancy(string id)
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
                    Price_Per_Night = 100;
                    break;

                case "Double":
                    startroomnumber = 601;
                    endroomnumber = 900;
                    Price_Per_Night = 150;
                    break;

                case "Suite":
                    startroomnumber = 901;
                    endroomnumber = 1000;
                    Price_Per_Night = 250;
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






        // CHECKIn

        //Check-In and Check-Out Implementation 
        // Might use Interface for multiple inheritance

        //CheckIn Variables
        /*--------------------------------------------------------------------------------------------------------*/

        //Dates

        protected int Days_number;

        public DateOnly ArrivalDate;
        public TimeSpan ArrivalTime;

        public DateOnly DepartureDate;
        public TimeSpan DepartureTime;

        public string status;
        /*--------------------------------------------------------------------------------------------------------*/


        // Property of Number of Days
        public int Number_of_Days
        {
            get { return Days_number; }
            set { Days_number = value; }
        }

        /*--------------------------------------------------------------------------------------------------------*/
        public int RoomBill;

        DBAccess Db1 = new DBAccess(); //The Variable that will link to the Database

        public void CheckInDate(string Id)
        {
            Console.WriteLine("Enter the Date of the CheckIn in the format YYYY-MM-DD. ");
            string inputDate = Console.ReadLine();
            if (DateOnly.TryParse(inputDate, out ArrivalDate)) //Assigning the Arrival Date
            {
                Console.WriteLine($"You entered: {ArrivalDate}");

                //Storing Database
                Db1.CheckInDate(ArrivalDate, Id);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
            }
 
        }


        //Check the Payment Status
        public void PaymentStatus(string Id)
        {
            TimeSpan Status = new TimeSpan(18, 0, 0);

            if (ArrivalTime >= Status)
            {
                status = "Must Pay";
            }
            else
            {
                status = "No Obligation for Now";
            }
            Db1.UpdateArrivalStatus(status, Id);
        }

        //Storing the Arrival time of CheckIn
        public void CheckInTime(string Id)
        {
            TimeSpan Arrival1 = DateTime.Now.TimeOfDay;
            //  Hour = Arrival.Hours;
            //  Minute = Arrival.Minutes;

            //Console.WriteLine($"Arrival Time is {Hour}:{Minute}");
            Console.WriteLine($"Arrival Time is {Arrival1}");
            ArrivalTime = Arrival1;
            PaymentStatus(Id);
            Console.WriteLine($"Payment Status: {status}");
            Db1.UpdateArrivalTime(ArrivalTime, Id,status);
        }


        //Check Out

        public void CheckOutDate(string Id)
        {
            Console.WriteLine("Enter the Date of the Check Out in the format YYYY-MM-DD. ");
            string inputDate = Console.ReadLine();
            if (DateOnly.TryParse(inputDate, out DepartureDate)) //Assigning the Arrival Date
            {
                Console.WriteLine($"You entered: {DepartureDate}");

                //Storing Database
                Db1.CheckOutDate(DepartureDate, Id);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
            }

        }


        //Storing the Departure time of CheckOut
        public void CheckOutTime(string Id)
        {
            TimeSpan Departure = DateTime.Now.TimeOfDay;
            //  Hour = Arrival.Hours;
            //  Minute = Arrival.Minutes;

            //Console.WriteLine($"Arrival Time is {Hour}:{Minute}");
            Console.WriteLine($"Departure Time is {Departure}");
            DepartureTime = Departure;
            Db1.UpdateDepartureTime(Departure, Id);
        }


        //Editing reservation:
        public void EditCheckInDate(string id)
        {
            Console.WriteLine("Enter the New Date of the CheckIn in the format YYYY-MM-DD. ");
            string inputDate = Console.ReadLine();

            if (DateOnly.TryParse(inputDate, out ArrivalDate)) //Assigning the Arrival Date
                 Console.WriteLine($"You entered: {ArrivalDate}");

            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
            }

            DBAccess dbAccess = new DBAccess();
            dbAccess.UpdateCheckInDate(id, ArrivalDate);

        }

        //Edit Checkin And Checkout Methods
        public void EditCheckOutDate(string id)
        {
            Console.WriteLine("Enter the Date of the Check Out in the format YYYY-MM-DD. ");
            string inputDate = Console.ReadLine();

            if (DateOnly.TryParse(inputDate, out DepartureDate)) //Assigning the Arrival Date
                Console.WriteLine($"You entered: {DepartureDate}");

            else
                Console.WriteLine("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
            

            DBAccess dbAccess = new DBAccess();
            dbAccess.UpdateCheckOutDate(id, DepartureDate);
        }




        public void Bill()
        {
            Days_number = DepartureDate.Day - ArrivalDate.Day;
            RoomBill = Days_number * Price_Per_Night;
            Console.WriteLine($"Room Bill: {RoomBill}");
        }





    }//End of Class
}//End of Program