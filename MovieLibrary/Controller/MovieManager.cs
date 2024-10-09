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

        //Check weather the movies list is empty or not to print the movie
        public bool MovieDisplayCheck()
        {
            if (movies.Count > 0)
            {
                return true;
            }
            throw new MovieListEmptyException("NO Movies Found!... Please Enter the Movie");
        }

        //Cheack movie list size, to deside we can add movie or not 
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


        //Check the rating given buy user is correct or not
        public bool RateAMovie(double rating, int index)
        {
            if(rating <=5)
            {
                movies[index].MovieVote++;
                movies[index].MovieSumRating += rating;
                movies[index].MovieRating = movies[index].MovieSumRating / movies[index].MovieVote;
                return true;
            }
            throw new InvalidRatingValueException("Please Enter The Rating Less Than '5' To  Rate a Movie");
           
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

        //Find the movie by id and return true if exist and also give the index of the list
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

        //Find the movie by name and return true if exist and also give the index of the list
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


        //Check if the id is already exist or not to add the movies
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
        // Remove Movie by its index
        public void RemoveMovieByIndex(int index)
        {
            movies.RemoveAt(index);
        }
        public Movie GetMovieByIndex(int index)
        {
            return movies[index];
        }

        // Edit part
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
