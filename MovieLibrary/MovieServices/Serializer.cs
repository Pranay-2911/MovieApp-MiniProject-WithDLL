using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.MovieServices
{
    public class Serializer
    {
        private static string filePath = "C:\\Users\\Pranay Raut\\Desktop\\DOTNET\\Mini Project\\MovieApp-MiniProject\\MovieApp-MiniProject\\movies.json";


        public static List<Movie> DeserializeMovies()
        {
            if (File.Exists(filePath))
            {
                string moviesData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Movie>>(moviesData);
            }
            return new List<Movie>();
        }


        public static void SerializeMovies(List<Movie> movies)
        {
            string jsonData = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
