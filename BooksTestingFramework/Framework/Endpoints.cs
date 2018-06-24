using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksTestingFramework.Framework
{
    public static class Endpoints
    {
        public static string BaseEndpoint = @"http://localhost:9000/";
        public static string BooksEndpoint ="api/books/";
        public static string IdBookEndpoint(int id)
        {
            return $"api/books/{id}";
        }
        public static string DeleteBookEndpoint(int id)
        {
            return $"api/books/{id}";
        }
        public static string UpdateBookEndpoint(int id)
        {
            return $"api/books/{id}";
        }
        public static string SearchBookEndpoint(string title)
        {
            return $"api/books?title={title}";
        }

        public static string SearchBookEndpointID(int id)
        {
            return $"api/books?id={id}";
        }

        public static string SearchBookEndpointAuthor(string author)
        {
            return $"api/books?author={author}";
        }

        public static string SearchBookEndpointDescription(string Description)
        {
            return $"api/books?description={Description}";
        }
    }
}
