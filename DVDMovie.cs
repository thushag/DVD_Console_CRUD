using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    public class DVDMovie:Movie
    {
        public double DiscWeight { get; set; }
        public TimeSpan Duration { get; set; }

        public DVDMovie(int movieId, string title, string director, decimal rentalPrice, double discWeight, TimeSpan duration)
            : base(movieId, title, director, rentalPrice)
        {
            DiscWeight = discWeight;
            Duration = duration;
        }

        public override string DisplayMovieInfo()
        {
            return base.DisplayMovieInfo() + $", Disc Weight: {DiscWeight}g, Duration: {Duration}";
        }

    }
}
