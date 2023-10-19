using Microsoft.Data.SqlClient;

namespace Sql_Con
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a Query");
            Console.WriteLine("\n1.Add customer details. \n2.Get all customers details.\n3.Delete any one customer from database.\n4.Update customer salary ");
            int option = Convert.ToInt32(Console.ReadLine());
            string connectionString = "Server=DESKTOP-UUUJ8RS\\SQLEXPRESS;Database=Grocery_Store;User Id=sa;Password=Test@123;Encrypt=false;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                switch (option)
                {
                    case 1:
                        string insertQuery = "INSERT INTO Customer (CustomerName, Phone, Address) VALUES (@CustomerName, @Phone, @Address)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerName", "Yash");
                            command.Parameters.AddWithValue("@Phone", "1234567890");
                            command.Parameters.AddWithValue("@Address", "America");

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Customer details added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add customer details.");
                            }
                        }
                        break;
                        case 2:
                        string selectQuery = "SELECT * FROM Customer";
                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Customer ID: {reader["CustomerId"]}, Name: {reader["CustomerName"]}, Phone: {reader["Phone"]}, Address: {reader["Address"]}");
                                }
                            }
                        }
                        break;
                        case 3:
                        string deleteQuery = "DELETE FROM Customer WHERE CustomerName = @CustomerName";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerName", "Yash");

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Customer deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Customer not found or failed to delete.");
                            }
                        }
                        break;
                        case 4:
                        string updateQuery = "UPDATE Customer SET Salary = @Salary WHERE CustomerName = @CustomerName";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Salary", 60000.00);
                            command.Parameters.AddWithValue("@CustomerName", "Yash");

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Customer salary updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
                        }
                        break;
                        case 5:
                        Console.WriteLine("Exit");
                        return;


                }
            }
        }
    }
}