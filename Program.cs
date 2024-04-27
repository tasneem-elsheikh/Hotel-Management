using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
namespace Hotel_Management_System
{
    internal class Program

    {
        public class Meal
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }


            public Meal(string name, decimal price, string description)
            {
                Name = name;
                Price = price;
                Description = description;
            }
        }
        public class MealPurchase
        {
            public Meal Meal { get; set; }
            public int Quantity { get; set; }
            public Payment Payment { get; private set; }


            public MealPurchase(Meal meal, int quantity)
            {
                Meal = meal;
                Quantity = quantity;
            }

            public decimal GetTotalPrice()
            {
                return Meal.Price * Quantity;
            }
            public void RecordPayment(decimal amount, PaymentType paymentType)
            {
                if (Payment == null)  // Ensures that a payment can only be recorded once
                {
                    Payment = new Payment(amount, paymentType);
                }
                else
                {
                    Console.WriteLine("Payment has already been recorded for this purchase.");
                }

            }
            public void BillCurrentRoom()
            {

                // Check if payment has been recorded
                if (Payment == null)
                {
                    // Logic to bill the current room (or guest)
                    // For demonstration, let's assume there's a method to bill the room
                    BillRoom(GetTotalPrice());
                }
                else
                {
                    Console.WriteLine("Payment has already been recorded for this purchase.");
                }
            }
            private void BillRoom(decimal amount)
            {

                Console.WriteLine($"Room billed for {amount} for {Quantity} {Meal.Name} ");
            }
        }
        public class MealTracker
        {
            private List<MealPurchase> purchases;

            public MealTracker()
            {
                purchases = new List<MealPurchase>();
            }

            public void AddPurchase(MealPurchase purchase)
            {
                purchases.Add(purchase);
            }

            public void PrintAllPurchases()
            {
                foreach (var purchase in purchases)
                {
                    Console.WriteLine($"Meal: {purchase.Meal.Name}, Quantity: {purchase.Quantity}, Total: {purchase.GetTotalPrice()}");

                    if (purchase.Payment != null)
                    {
                        Console.WriteLine($"Paid {purchase.Payment.Amount:C2} via {purchase.Payment.PaymentType}");
                    }
                    else
                    {
                        Console.WriteLine("Payment has not been recorded.");
                    }
                }
            }
        }
        public class RestaurantReservation
        {
            public int NumberOfGuests { get; set; }
            public string SpecialRequests { get; set; }

            public RestaurantReservation(int numberOfGuests, string specialRequests)
            {

                NumberOfGuests = numberOfGuests;
                SpecialRequests = specialRequests;
            }
        }
        public class RoomServiceReservation
        {
            public int RoomNumber { get; set; }
            public List<Meal> RequestedItems { get; set; }

            public RoomServiceReservation(int roomNumber, List<Meal> requestedItems)
            {
                RoomNumber = roomNumber;
                RequestedItems = requestedItems;

            }
        }

        public enum PaymentType
        {
            Cash,
            CreditCard,
            DebitCard,

        }

        public class Payment
        {
            public decimal Amount { get; set; }
            public PaymentType PaymentType { get; set; }


            public Payment(decimal amount, PaymentType paymentType)
            {
                Amount = amount;
                PaymentType = paymentType;
            }
        }









        static void Main(string[] args)
        {
            int Role = 0;
            int Operation = 0;

            Console.WriteLine("Please identify your role and enter its number whether you are: 1.Manager, 2.Receptionist or 3.Food Service");
            Role = int.Parse(Console.ReadLine());

            if (Role == 1) //manager
            {

            }

            else if (Role == 2) //receptionist
            {
                while (true)
                {
                    Reservation G1 = new Reservation();
                    Console.WriteLine("What do you desire to do: 1.Booking, 2.Check-in, 3.Check-out or 4.Edit");
                    Operation = int.Parse(Console.ReadLine());

                    //Booking
                    if (Operation == 1)
                    {
                        G1.InsertGuestInfo();
                        G1.CheckInDate(G1.Id);
                        G1.GetVacancy(G1.id);
                    }

                    //Check-In
                    else if (Operation == 2)
                    {
                        G1.CheckInTime(G1.Id);
                       // G1.occupyRoom(room_number: G1.RoomNumber);
                        //G1.CheckIn();
                    }

                    //Check-Out
                    else if (Operation == 3)
                    {
                        //G1.emptyRoom();
                        //G1.getCheckoutInfo();
                    }

                    //Edit
                    else if (Operation == 4)
                    {
                        Console.WriteLine("Enter the operation: 1-Delete Reservation \n 2-Edit Reservation \n 3-Guest Info");
                        int Edit = int.Parse(Console.ReadLine());

                        //Delete
                        if (Edit == 1)
                        {
                            //Doesnt need to search
                           // G1 = G1.SearchCustomerById(G1.Id); 
                           // G1 = G1.Returning_ReservationInfo(G1.Id);
                            G1.DeleteReservation(G1.Id);
                        }

                        //Edit Reservation date
                        if(Edit == 2)
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

            else if (Role == 3) // food service
            {

            }

            else
            {
                Console.WriteLine("INVALID DATA ENTERED PLEASE START AGAIN");
            }



            return;


            //Reservation r = new Reservation();
            //r.id = "123456789";
            //r.CheckInDate(r.id);
            //r.CheckOutDate(r.id);
            //r.EditCheckInDate(r.id);
            //r.EditCheckOutDate(r.id);
            //r.GetVacancy(r.id);


        }

    }
}