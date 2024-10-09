using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var manager = new MovieManager();
        //    int option = 0;

        //    do
        //    {
        //        Console.WriteLine("\nMovie Rental Management System:");
        //        Console.WriteLine("1. Add a Movie");
        //        Console.WriteLine("2. View All Movies");
        //        Console.WriteLine("3. Update a Movie");
        //        Console.WriteLine("4. Delete a Movie");
        //        Console.WriteLine("5. Exit");
        //        Console.Write("Choose an option: ");
        //        if (!int.TryParse(Console.ReadLine(), out option))
        //        {
        //            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        //            continue;
        //        }

        //        switch (option)
        //        {
        //            case 1:
        //                Console.Write("Enter Movie ID: ");
        //                int id = int.Parse(Console.ReadLine());
        //                Console.Write("Enter Movie Title: ");
        //                string title = Console.ReadLine();
        //                Console.Write("Enter Movie Director: ");
        //                string director = Console.ReadLine();
        //                Console.Write("Enter Movie Rental Price: ");
        //                decimal price = decimal.Parse(Console.ReadLine());
        //                manager.CreateMovie(id, title, director, price);
        //                break;

        //            case 2:
        //                manager.ReadMovies();
        //                break;

        //            case 3:
        //                Console.Write("Enter the Movie ID to update: ");
        //                id = int.Parse(Console.ReadLine());
        //                Console.Write("Enter new Title: ");
        //                title = Console.ReadLine();
        //                Console.Write("Enter new Director: ");
        //                director = Console.ReadLine();
        //                Console.Write("Enter new rental Price: ");
        //                price = decimal.Parse(Console.ReadLine());
        //                manager.UpdateMovie(id, title, director, price);
        //                break;

        //            case 4:
        //                Console.Write("Enter the Movie ID to delete: ");
        //                id = int.Parse(Console.ReadLine());
        //                manager.DeleteMovie(id);
        //                break;

        //            case 5:
        //                Console.WriteLine("Exiting the system. Goodbye!");
        //                break;

        //            default:
        //                Console.WriteLine("Invalid option. Please choose between 1 and 5.");
        //                break;
        //        }

        //    } while (option != 5);
        //}

        static void Main(string[] args)
        {
            var repository = new MovieRepository();
            var movieManager = new MovieManager();
            int option = 0;

            do
            {
                
                Console.WriteLine("\nMovie Rental Management System:");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.Write("Enter Movie Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Movie Director: ");
                        string director = Console.ReadLine();
                        Console.Write("Enter Movie Rental Price: ");

                        decimal price = movieManager.ValidateMovieRentalPrice();
                        
                        repository.CreateMovie(title, director, price);
                        
                        break;

                    case 2:
                        repository.ReadMovies();
                        break;

                    case 3:
                        Console.Write("Enter the Movie ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.Write("Enter new Title: ");
                            title = Console.ReadLine();
                            Console.Write("Enter new Director: ");
                            director = Console.ReadLine();

                            decimal newprice = movieManager.ValidateMovieRentalPrice();
                            
                            repository.UpdateMovie(updateId, title, director, newprice);
                           
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid Movie ID.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter the Movie ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            repository.DeleteMovie(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Movie ID.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 5.");
                        break;
                }

            } while (option != 5);
        }
    }
}
