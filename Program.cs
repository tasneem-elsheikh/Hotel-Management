using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
namespace Hotel_Management_System
{
    internal class Program

    {

        static void Main(string[] args)
        {
            int Role = 0;
            int Operation = 0;
            
            Console.WriteLine("Please identify your role and enter its number whether you are: 1.Manager, 2.Receptionist or 3.Food Service");
            Role = int.Parse(Console.ReadLine());

            if(Role==1) //manager
            {

            }

            else if(Role==2) //receptionist
            { 
                while(true) 
                {
                    Reservation G1 = new Reservation();
                    Console.WriteLine("What do you desire to do: 1.Booking, 2.Check-in, 3.Check-out or 4.Edit");
                    Operation = int.Parse(Console.ReadLine());

                    //Booking
                    if (Operation==1) 
                    {
                        G1.InsertGuestInfo();
                        G1.CheckIn();
                        G1.GetVacancy();
                    }

                    //Check-In
                    else if(Operation==2) 
                    {
                        G1.CheckInTime();
                        G1.occupyRoom(room_number: G1.RoomNumber);
                        //G1.CheckIn();
                    }

                    //Check-Out
                    else if(Operation==3) 
                    {
                        //G1.emptyRoom();
                        //G1.getCheckoutInfo();
                    }

                    //Edit
                    else if(Operation==4)
                    {
                        Console.WriteLine("Enter the operation: 1-Delete Reservation \n 2-Edit Data \n ");
                            int Edit = int.Parse(Console.ReadLine());

                        //Delete
                        if (Edit == 1)
                        {
                            Console.WriteLine("Enter the Guest's Id: ");
                            G1.Id = Console.ReadLine();
                            G1 = G1.SearchCustomerById(G1.Id);
                            G1.DeleteClient(G1.Id);
                        }


                    }


                    else
                    {
                        Console.WriteLine("INVALID DATA ENTERED PLEASE START AGAIN");
                    }
                }
            }

            else if(Role==3) // food service
            {

            }

            else
            {
                Console.WriteLine("INVALID DATA ENTERED PLEASE START AGAIN");
            }

            return;
        }

    }
}