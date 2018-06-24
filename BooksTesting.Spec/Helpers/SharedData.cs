using BooksTestingFramework.DTOs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksTesting.Spec.Helpers
{
    // this class is used to pass the sared list so books generated thru the tests can be added to it so they will be cleared at the end of execution
    public static class SharedData
    {
        public static ConcurrentBag<BookDTO> BooksList = new ConcurrentBag<BookDTO>();
        public static ConcurrentBag<BookDTO> AllBooks = new ConcurrentBag<BookDTO>();
        public static ConcurrentBag<BookDTO> AllBooksTitleSearch = new ConcurrentBag<BookDTO>();
        public static ConcurrentBag<BookDTO> AllBooksAuthorSearch = new ConcurrentBag<BookDTO>();
        public static ConcurrentBag<BookDTO> AllBooksIDSearch = new ConcurrentBag<BookDTO>();
        public static ConcurrentBag<BookDTO> AllBooksDescriptionSearch = new ConcurrentBag<BookDTO>();
    }
}
