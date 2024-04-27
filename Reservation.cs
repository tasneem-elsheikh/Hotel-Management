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
            set
            {
                //if (value.Length == 14) // Checking the length of the national id
                //{
                    id = value;
                //}
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
        //public void BookRoom(string firstName, string lastName, string phoneNumber, int roomNumber, string id)
        //{
        //    dbAccess.InsertGuestInfo(firstName, lastName, phoneNumber, roomNumber, id);

        //}

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


       
        /*--------------------------------------------------------------------------------------------------------*/




        public string GetVacancy(string id)
        {

            Console.WriteLine("Enter the room type the Guest desires, whether Single, Double, or Suite:");
            RoomType = Console.ReadLine();

            int startRoomNumber = 0;
            int endRoomNumber = 0;
            switch (RoomType)
            {
                case "Single":
                    startRoomNumber = 1;
                    endRoomNumber = 600;
                    Price_Per_Night = 100;
                    break;

                case "Double":
                    startRoomNumber = 601;
                    endRoomNumber = 900;
                    Price_Per_Night = 150;
                    break;

                case "Suite":
                    startRoomNumber = 901;
                    endRoomNumber = 1000;
                    Price_Per_Night = 250;
                    break;

                default:
                    return "Invalid room type !!";
            }

            DateTime arrivalDateTime = new DateTime(ArrivalDate.Year, ArrivalDate.Month, ArrivalDate.Day);
            DateTime departureDateTime = new DateTime(DepartureDate.Year, DepartureDate.Month, DepartureDate.Day);

            for (int i = startRoomNumber; i <= endRoomNumber; i++)
            {
                if (!IsRoomOccupied(i, arrivalDateTime, departureDateTime))
                {
                    RoomNumber = i;
                    BookRoom(RoomNumber, id); // Book the room if it's available
                    return $"Room number {i} is vacant";
                }
            }

            return $"All rooms of type {RoomType} are occupied";
        }

        private bool IsRoomOccupied(int roomNumber, DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            
                DBAccess dbAccess = new DBAccess(); // Initialize DBAccess
                return dbAccess.IsRoomOccupiedForDates(roomNumber, checkInDateTime, checkOutDateTime);
        }


        private void BookRoom(int roomNumber, string id)
        {
            DateTime arrivalDateTime = new DateTime(ArrivalDate.Year, ArrivalDate.Month, ArrivalDate.Day);
            DateTime departureDateTime = new DateTime(DepartureDate.Year, DepartureDate.Month, DepartureDate.Day);

                               
                DBAccess dbAccess = new DBAccess(); // Initialize DBAccess

            if (!dbAccess.IsRoomOccupiedForDates(roomNumber, arrivalDateTime, departureDateTime))
            {
                dbAccess.UpdateRoomNumber(id, roomNumber); // Book the room in the database
                dbAccess.UpdateRoomNumber_Guestinfo(id, roomNumber);
                Console.WriteLine($"Room {roomNumber} is now booked successfully");
            }
            else
            {
                Console.WriteLine($"Room {roomNumber} is already occupied");
            }

        }


        // CHECKIn

        //Check-In and Check-Out Implementation 


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