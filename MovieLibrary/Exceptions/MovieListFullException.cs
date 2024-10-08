using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    public class MovieListFullException : Exception
    {
        public MovieListFullException(string message) : base(message) { }
    }
}
