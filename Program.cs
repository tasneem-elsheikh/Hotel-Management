using System.Data.SqlClient;
using System.Data;
namespace Hotel_Management_System
{
    internal class Program

    {

        static void Main(string[] args)
        {
            Reservation r1 = new Reservation("Mahmoud", "Mohamed", "01020592780", 12, "Single");
            r1.BookRoom("Mahmoud", "Mohamed", "01020592780", 12, 1221);



            //DBAccess dBAccess = new DBAccess();

            //string nname = "Mahmoud";
            //int Ageeee = 19;
            //int IDDDD = 5;

            ////Inserting into table
            //SqlCommand insertCommand = new SqlCommand("insert into UserTab(Name,ID,Age) values(@Namee, @IDD, @Age)");
            //insertCommand.Parameters.Add(new SqlParameter("@ID", IDDDD));
            //insertCommand.Parameters.Add(new SqlParameter("@Name", nname));
            //insertCommand.Parameters.Add(new SqlParameter("@Age", Ageeee));

            //int rowsAffected = dBAccess.executeQuery(insertCommand);

            //Console.WriteLine($"Rows affected: {rowsAffected}");




            //deleting from table

            //SqlCommand deleteCommand = new SqlCommand("DELETE FROM UserTab WHERE ID = @ID");
            //deleteCommand.Parameters.Add(new SqlParameter("@ID", ID));

            //dBAccess.executeQuery(deleteCommand);


            // string id = "12";
            // //Connection String
            //  string ConnectionString = "Data Source=LAPTOP-3MO76OTM\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";



            // SqlConnection Connection = new SqlConnection(ConnectionString);
            // Connection.Open();
            // SqlCommand cmd = new SqlCommand("insert into Clientinfo values (@ID,@Name,@Age)",Connection);
            // cmd.Parameters.AddWithValue("@Name", id);
            // cmd.Parameters.AddWithValue("@ID", int.Parse(id));

            // cmd.Parameters.AddWithValue("@Age", int.Parse(id));

            //// cmd.ExecuteNonQuery();




            //Connection.Close();
        }
    }
}