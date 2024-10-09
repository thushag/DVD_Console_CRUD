using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    public class MovieRepository
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MovieRentalManagement;Trusted_Connection=true;TrustServerCertificate=true";

        public void CreateMovie(string title, string director, decimal rentalPrice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Movies (Title, Director, RentalPrice) VALUES (@Title, @Director, @RentalPrice)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", CapitalizeTitle(title));
                        command.Parameters.AddWithValue("@Director", director);
                        command.Parameters.AddWithValue("@RentalPrice", rentalPrice);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Movie added to the database successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void ReadMovies()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Movies";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No movies available.");
                            return;
                        }

                        Console.WriteLine("List of Movies:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["MovieId"]}, Title: {reader["Title"]}, Director: {reader["Director"]}, Rental Price: {reader["RentalPrice"]:C}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void UpdateMovie(int id, string title, string director, decimal rentalPrice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Movies SET Title = @Title, Director = @Director, RentalPrice = @RentalPrice WHERE MovieId = @MovieId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", id);
                        command.Parameters.AddWithValue("@Title", CapitalizeTitle(title));
                        command.Parameters.AddWithValue("@Director", director);
                        command.Parameters.AddWithValue("@RentalPrice", rentalPrice);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Movie updated successfully.");
                        else
                            Console.WriteLine("Movie not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DeleteMovie(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Movies WHERE MovieId = @MovieId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Movie deleted successfully.");
                        else
                            Console.WriteLine("Movie not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public string CapitalizeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return title;

            var words = title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join("", words);
        }
    }


}
