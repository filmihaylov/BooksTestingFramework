using BooksTestingFramework.DTOs;
using BooksTestingFramework.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace BooksTesting.Spec.Helpers
{
    // This Class ads Initial data before all tests and clears all data at the end of execution
    [Binding]
    public class Hooks
    {
        private static HttpClientContext _clientContext = new HttpClientContext();
        private static ConcurrentBag<BookDTO> _booksList = SharedData.BooksList;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            generateBooks().Wait();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            clearBooks().Wait();
        }

        private static async Task<List<HttpResponseMessage>> generateBooks()
        {
            List<HttpResponseMessage> responces = new List<HttpResponseMessage>();
            populateBooksList(10);
            foreach (var book in _booksList)
            {
                var responce =  _clientContext.Client.Post(Endpoints.BooksEndpoint, book);
                var awaytedResponce = await responce;
                responces.Add(awaytedResponce);
            }

            return responces;
        }

        private static void populateBooksList(int books)
        {
            for (int i = 1; i <= books; i++)
            {
                _booksList.Add(new BookDTO
                {
                    Id = i,
                    Author = "InitialGeneratedAuthor",
                    Description = "InitialGeneratedDescription",
                    Title = "InitialGeneratedTitle"
                });
            }
        }

        private static async Task<List<HttpResponseMessage>> clearBooks()
        {
            List<HttpResponseMessage> responces = new List<HttpResponseMessage>();
            foreach (var book in _booksList)
            {
                var responce = _clientContext.Client.Delete(Endpoints.DeleteBookEndpoint(book.Id));
                var awaytedResponce = await responce;
                responces.Add(awaytedResponce);
            }
            return responces;
        }
    }
}

