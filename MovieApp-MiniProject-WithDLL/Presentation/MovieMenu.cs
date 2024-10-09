using MovieLibrary.Controller;
using MovieLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp_MiniProject_WithDLL.Presentation
{
    public class MovieMenu
    {
        static MovieManager manager = new MovieManager();
        public static void GetMovieMenu()
        {
            Console.WriteLine("============= Welcome To Movies App =============");
            Console.WriteLine();

            bool check = true;

            while (check)
            {
                Console.WriteLine("============== Operation ==============");
                Console.WriteLine($"1. Add New Movies \n" +
                                  $"2. Rate A Movie \n" +
                                  $"3. Edit Movie \n" +
                                  $"4. Find Movie by Id \n" +
                                  $"5. Find Movie by Name \n" +
                                  $"6. Display All Movies \n" +
                                  $"7. Remove Movie by Id \n" +
                                  $"8. Remove Movie by Name \n" +
                                  $"9. Clear All \n" +
                                  $"10. Exit \n");
                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }

                Switches(choice, ref check);
            }

            static void Switches(int choice, ref bool check)
            {
                switch (choice)
                {
                    case 1:
                        CheckMovieList();
                        break;
                    case 2:
                        RateMovie();
                        break;
                    case 3:
                        EditMovie();
                        break;
                    case 4:
                        FindMovieById();
                        break;
                    case 5:
                        FindMovieByName();
                        break;
                    case 6:
                        DisplayMovie();
                        break;
                    case 7:
                        RemoveMovieById();
                        break;
                    case 8:
                        RemoveMovieByname();
                        break;
                    case 9:
                        ClearMovie();
                        break;
                    case 10:
                        Serializer(ref check);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }

            // Display movies using the manager
            static void DisplayMovie()
            {
                try
                {
                    if (manager.MovieDisplayCheck())
                    {
                        manager.PrintDetails();
                    }
                }
                catch (MovieListEmptyException me)
                {
                    Console.WriteLine(me.Message);
                }
            }

            // Check if we can add more movies
            static void CheckMovieList()
            {
                try
                {
                    if (manager.MovieSizeCheckToADD())
                    {
                        AddMovies();
                    }
                }
                catch (MovieListFullException mf)
                {
                    Console.WriteLine(mf.Message);
                }
            }

            // Adding movies using the manager
            static void AddMovies()
            {

                try
                {
                    Console.WriteLine("Enter the Movie ID");
                    int moviesId = int.Parse(Console.ReadLine());
                    if (!manager.MovieIdExist(moviesId))
                    {

                        Console.WriteLine("Enter the Movie Name");
                        string movieName = Console.ReadLine();
                        Console.WriteLine("Enter the Movie Genre");
                        string movieGenre = Console.ReadLine();
                        Console.WriteLine("Enter the Movie Year");
                        int movieYear = int.Parse(Console.ReadLine());

                        manager.AddMovies(moviesId, movieName, movieGenre, movieYear);
                        manager.ToSerialization();
                        Console.WriteLine("Movie Added Successfully");
                    }
                }
                catch (MovieIdExistException m)
                {
                    Console.WriteLine(m.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static void RateMovie()
            {

                try
                {
                    Console.WriteLine("Enter the MovieID to rate a Movie");
                    int id = int.Parse(Console.ReadLine());
                    int index = 0;

                    if (manager.FindMovieId(id, ref index))
                    {
                        RatingAMovieWithId(index);
                    }
                }
                catch (MovieIdDoNotExistException mId)
                {
                    Console.WriteLine(mId.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);   
                }
            }
            static void RatingAMovieWithId(int index)
            {
                try
                {
                    Console.WriteLine($"Enter your rating for {manager.GetMovieByIndex(index).MovieName} Movie, Out OF FIVE !!!!!");
                    double rating = double.Parse(Console.ReadLine());
                    if (manager.RateAMovie(rating, index))
                    {
                        Console.WriteLine("Thank you for your rating");
                    }
                }
                catch(InvalidRatingValueException ir)
                {
                    Console.WriteLine(ir.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Clear movies using the manager
            static void ClearMovie()
            {
                manager.ClearMovie();
                Console.WriteLine("All Movies Cleared.");
            }

            // Save and exit the program
            static void Serializer(ref bool check)
            {
                manager.ToSerialization();
                check = false;
                Console.WriteLine("Saved Successfully");
            }

            static void FindMovieById()
            {

                try
                {
                    Console.WriteLine("Enter The Movie Id for to Find the Movie");
                    int id = int.Parse(Console.ReadLine());
                    int index = 0;
                    if (manager.FindMovieId(id, ref index))
                    {
                        Console.WriteLine(manager.GetMovieByIndex(index).DisplayMovie());
                    }
                }
                catch (MovieIdDoNotExistException mid)
                {
                    Console.WriteLine(mid.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }

            static void FindMovieByName()
            {


                try
                {
                    Console.WriteLine("Enter The Movie Name for to Find the Movie");
                    string name = Console.ReadLine();
                    int index = 0;
                    if (manager.FindMovieByName(name, ref index))
                    {
                        Console.WriteLine(manager.GetMovieByIndex(index).DisplayMovie());
                    }
                }
                catch (MovieNameDoNotExistException mname)
                {
                    Console.WriteLine(mname.Message);
                }
                catch (Exception e)
                {    
                    Console.WriteLine(e.Message);
                }
            }

            static void RemoveMovieById()
            {

                try
                {
                    Console.WriteLine("Enter The Movie Id to Delete the Movie");
                    int id = int.Parse(Console.ReadLine());
                    int index = 0;
                    if (manager.FindMovieId(id, ref index))
                    {
                        manager.RemoveMovieByIndex(index);
                        Console.WriteLine($"Movie for Id : {id} deleted Sucessfully...");
                    }
                }
                catch (MovieIdDoNotExistException mid)
                {
                    Console.WriteLine(mid.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            static void RemoveMovieByname()
            {

                try
                {
                    Console.WriteLine("Enter The Movie Name to Delete the Movie");
                    string name = Console.ReadLine();
                    int index = 0;
                    if (manager.FindMovieByName(name, ref index))
                    {
                        manager.RemoveMovieByIndex(index);
                        Console.WriteLine($"The Movie {name} was removed.");
                    }
                }
                catch (MovieNameDoNotExistException mname)
                {
                    Console.WriteLine(mname.Message);
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
            }

            static void EditMovie()
            {
                try
                {
                    Console.WriteLine("Enter the Movie Id to Edit the Movie");
                    int id = int.Parse(Console.ReadLine());
                    int index = 0;
                    if (manager.FindMovieId(id, ref index))
                    {
                        bool check = true;
                        EditOperationLoop(ref check, index);
                    }
                }
                catch (MovieIdDoNotExistException mid)
                {
                    Console.WriteLine(mid.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }

            static void EditOperationLoop(ref bool check, int index)
            {
                while (check)
                {
                    EditOperation(ref check, index);
                }
            }
            static void EditOperation(ref bool check, int index)
            {

                Console.WriteLine($"1. Edit Movie Name \n" +
                    $"2. Edit Movie Genre \n" +
                    $"3. Edit Movie Year \n" +
                    $"4. Exit Operation \n");
                Console.WriteLine("Enter the number for Edit in Movie");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        EditName(index);
                        break;
                    case 2:
                        Editgenre(index);
                        break;
                    case 3:
                        EditYear(index);
                        break;
                    case 4:
                        check = false;
                        break;
                   
                }

            }

            static void EditName(int index)
            {
                try
                {
                    Console.WriteLine("Enter name to change the movie name");
                    string name = Console.ReadLine();
                    manager.EditName(index, name);
                    Console.WriteLine("Successfully Edited");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            static void Editgenre(int index)
            {
                try
                {
                    Console.WriteLine("Enter genre to change the movie genre");
                    string genre = Console.ReadLine();
                    manager.EditGenre(index, genre);
                    Console.WriteLine("Successfully Edited");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }
            static void EditYear(int index)
            {
                try
                {
                    Console.WriteLine("Enter year to change the movie Year");
                    int year = int.Parse(Console.ReadLine());
                    manager.EditId(index, year);
                    Console.WriteLine("Successfully Edited");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }


        }
    }
}
