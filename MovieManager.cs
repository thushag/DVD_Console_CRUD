using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    public class MovieManager
    {
        private List<Movie>movies = new List<Movie>();
        public void CreateMovie(int id, string title, string director, decimal rentalPrice)
        {
                movies.Add(new Movie(id, title, director, rentalPrice));
                Console.WriteLine("Movie added successfully.");
            
        }

        public void ReadMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            Console.WriteLine("List of Movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        public void UpdateMovie(int id, string title, string director, decimal rentalPrice)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                movie.Title = title;
                movie.Director = director;
                movie.RentalPrice = rentalPrice;
                Console.WriteLine("Movie updated successfully.");
            }
            else
            {
                Console.WriteLine("Movie not found..");
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                movies.Remove(movie);
                Console.WriteLine("Movie deleted successfully.");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }

        public decimal ValidateMovieRentalPrice()
        {
           decimal price;

            do
            {
                Console.WriteLine("Enter DVD Price: ");
                price = decimal.Parse(Console.ReadLine());
                if (price <= 0)
                {
                    Console.WriteLine("DVD Price Shoud be Positive Number.");
                }

            } while (price <= 0);
            return price;
        }

    }
}
