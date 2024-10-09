using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public decimal RentalPrice { get; set; }

        public static int TotalMovies { get; private set; } = 0;


        public Movie(int movieId,string title,string director,decimal rentalPrice)
        {
            MovieId = movieId;
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
            TotalMovies++;
        }

        public override string ToString()
        {
            return DisplayMovieInfo();
        }

        public virtual string DisplayMovieInfo()
        {
            return $"ID:{MovieId},Title:{Title},Director{Director},Rentalprice:{RentalPrice}";
        }

        
    }
}
