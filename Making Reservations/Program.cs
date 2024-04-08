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
        protected string type;
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
            get { return type; }
            set
            {
                if (value == "Single" || value == "Double" || value == "King" || value == "Suite")
                {
                    type = value;
                }
            }
        }

        public Reservation(string firstname, string secondname, string phone_number, int room_number, string type, bool occupancy)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.phone_number = phone_number;
            this.room_number = room_number;
            this.type = type;
            this.occupancy = occupancy;
        }

        public void InsertingCustomerInfo()
        {
            Console.WriteLine("Please enter the customer's first name then second name:");
            firstname = Console.ReadLine();
            secondname = Console.ReadLine();

            Console.WriteLine("Please enter the customer's phone number and make sue they consist of 11 digits");
            phone_number = Console.ReadLine();
        }

        public string GetVacancy()
        {
            Console.WriteLine("Enter the type of room the customer desires, whether Single, Double, King or Suite:");
            type = Console.ReadLine();

            if (type == "Single")
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

                return "all rooms of this type are occupied";
            }
            

            else if (type == "Double")
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
                return $"all rooms of this type are occupied";
            }


            else if (type == "King")
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
                return $"all rooms of this type are occupied";
            }


            else if (type == "Suite")
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
        }//End of Class
    }//End of Program
}