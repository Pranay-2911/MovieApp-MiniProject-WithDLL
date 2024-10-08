using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.MovieServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Controller
{
    public class MovieManager
    {
        static List<Movie> movies;

        public MovieManager()  // Constructor with Deserialization
        {
            movies = Serializer.DeserializeMovies(); // Deserialize movies
        }

        public void ToSerialization() // Serializer
        {
            Serializer.SerializeMovies(movies);
        }

        // Get movie size (number of movies in the list)
        public int GetMovieSize()
        {
            return movies.Count;
        }

        public bool MovieDisplayCheck()
        {
            if (movies.Count > 0)
            {
                return true;
            }
            throw new MovieListEmptyException("NO Movies Found!... Please Enter the Movie");
        }

        public bool MovieSizeCheckToADD()
        {
            if (movies.Count < 5)
            {
                return true;
            }
            throw new MovieListFullException("Your Movie list is full");


        }
        // Print all movie details
        public void PrintDetails()
        {

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.DisplayMovie());
            }

        }


        public void RateAMovie(double rating, int index)
        {
            movies[index].MovieVote++;
            movies[index].MovieSumRating += rating;
            movies[index].MovieRating = movies[index].MovieSumRating / movies[index].MovieVote;
        }

        // Add a movie
        public void AddMovies(int moviesId, string movieName, string movieGenre, int movieYear)
        {
            movies.Add(new Movie(moviesId, movieName, movieGenre, movieYear));
        }

        // Clear the movie list
        public void ClearMovie()
        {
            movies.Clear(); // Clear all movies
            Serializer.SerializeMovies(movies); // Serialize after clearing
        }

        public bool FindMovieId(int id, ref int index)
        {
            int i = 0;
            foreach (var movie in movies)
            {

                if (movie.MovieId == id)
                {
                    index = i;
                    return true;
                }
                i++;

            }
            throw new MovieIdDoNotExistException($"The Movie for ID :{id} Does not Exist");
        }

        public bool FindMovieByName(string name, ref int index)
        {
            int i = 0;
            foreach (var movie in movies)
            {

                if (movie.MovieName == name)
                {
                    index = i;
                    return true;
                }
                i++;

            }
            throw new MovieNameDoNotExistException($"The :{name} Does not Exist");
        }
        public bool MovieIdExist(int id)
        {
            int i = 0;
            foreach (var movie in movies)
            {

                if (movie.MovieId == id)
                {
                    throw new MovieIdExistException($"The Movie for {id} already exist pls enter some differnt id");

                }
                i++;

            }
            return false;

        }
        public void RemoveMovieByIndex(int index)
        {
            movies.RemoveAt(index);
        }
        public Movie GetMovieByIndex(int index)
        {
            return movies[index];
        }
        public void EditId(int index, int id)
        {
            movies[index].MovieId = id;
        }

        public void EditName(int index, string name)
        {
            movies[index].MovieName = name;
        }
        public void EditGenre(int index, string genre)
        {
            movies[index].MovieGenre = genre;
        }
        public void EditYear(int index, int year)
        {
            movies[index].MovieYear = year;
        }
    }
}
