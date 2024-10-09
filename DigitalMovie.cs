using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_1
{
    public class DigitalMovie:Movie
    {
        public double FileSize { get; set; }
        public string Format { get; set; }

        public DigitalMovie(int movieId, string title, string director, decimal rentalPrice, double fileSize, string format)
            : base(movieId, title, director, rentalPrice)
        {
            FileSize = fileSize;
            Format = format;
        }

        public override string DisplayMovieInfo()
        {
            return base.DisplayMovieInfo() + $", File Size: {FileSize}MB, Format: {Format}";
        }

    }
}
