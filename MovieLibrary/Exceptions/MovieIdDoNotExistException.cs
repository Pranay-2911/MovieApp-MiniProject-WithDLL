using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    public class MovieIdDoNotExistException : Exception
    {
        public MovieIdDoNotExistException(string message) : base(message)
        {
        }
    }
}
