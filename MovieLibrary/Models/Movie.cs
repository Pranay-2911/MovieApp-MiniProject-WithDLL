using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public int MovieYear { get; set; }
        public double MovieRating { get; set; }

        public int MovieVote = 0;
        public double MovieSumRating = 0;
        public Movie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            MovieId = movieId;
            MovieName = movieName;
            MovieGenre = movieGenre;
            MovieYear = movieYear;
            MovieRating = 0.0;
        }

        //Printing part
        public string DisplayMovie()
        {
            return $"Movie ID : {MovieId} \n" +
                $"Movie Name : {MovieName} \n" +
                $"Movie Genre : {MovieGenre} \n" +
                $"Movie Year : {MovieYear} \n" +
                $"Movie Rating out of 5 : {MovieRating} Where {MovieVote} People has rated\n";
        }
    }
}
