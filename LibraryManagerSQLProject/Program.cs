using System;
using System.Data.SqlClient;
using System.Configuration;

namespace LibraryManagerSQLProject
{

    internal class Program
    {
        static string connectionString = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
        static void AddBook()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Books (Title, Author, Price) VALUES (@title, @author, @price)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Book added successfully!");
            }
        }

        static void DisplayAllBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id, Title, Author, Price FROM Books";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
                    }
                }
            }
        }

        static void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Books WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Book deleted successfully!");
                    else
                        Console.WriteLine("No book found with that ID.");
                }
            }
        }

        static void SearchBook()
        {
            Console.Write("Enter part/full title to search: ");
            string searchTitle = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id, Title, Author, Price FROM Books WHERE Title LIKE @title";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", "%" + searchTitle + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool found = false;
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
                            found = true;
                        }
                        if (!found)
                            Console.WriteLine("No books found with the given title.");
                    }
                }
            }
        }



        static void Main(string[] args)
        {
          
            while (true)
            {
                Console.WriteLine("\nLibrary Manager");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddBook(); break;
                    case 2: DisplayAllBooks(); break;
                    case 3: DeleteBook(); break;
                    case 4: SearchBook();break;
                    case 5: return;
                    default: Console.WriteLine("Invalid Choice!"); break;
                }
            }
        }
    }
}
