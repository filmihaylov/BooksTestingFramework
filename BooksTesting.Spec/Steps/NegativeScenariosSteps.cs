using BooksTesting.Spec.Helpers;
using BooksTestingFramework.DTOs;
using BooksTestingFramework.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace BooksTesting.Spec.Steps
{
    [Binding]
    public class NegativeScenariosSteps
    {
        private HttpClientContext _clientContext;
        private static ConcurrentBag<BookDTO> _booksList = SharedData.BooksList;
        private static ConcurrentBag<BookDTO> allBooks = SharedData.AllBooks;
        private static ConcurrentBag<BookDTO> allBooksTitleSearch = SharedData.AllBooksTitleSearch;
        private static ConcurrentBag<BookDTO> allBooksAuthorSearch = SharedData.AllBooksAuthorSearch;
        private static ConcurrentBag<BookDTO> allBooksIdSearch = SharedData.AllBooksIDSearch;
        private static ConcurrentBag<BookDTO> allBooksDescriptionSearch = SharedData.AllBooksDescriptionSearch;

        public NegativeScenariosSteps(HttpClientContext clientContext)
        {
            this._clientContext = clientContext;
        }

        [Then(@"I should not be able to add the same book")]
        public async Task ThenIShouldNotBeAbleToAddTheSameBook(Table table)
        {
            var book = table.CreateInstance<BookDTO>();

            var response = await this._clientContext.Client.Post(Endpoints.BooksEndpoint, book);
            Assert.True(!response.IsSuccessStatusCode, "Duplicate Book Was Added");
            var message = JsonConvert.DeserializeObject<MessageDTO>(response.Content.ReadAsStringAsync().Result);
            Assert.True(message.Message.Contains("already exists"), "Duplicate Book Erorr message change");
        }

        [Then(@"the book should be not found with title '(.*)'")]
        public void ThenTheBookShouldBeNotFoundWithTitle(string title)
        {
            var list = allBooksTitleSearch.ToList();

            var bookFound = list.Find(i => i.Title.Equals(title));
            Assert.True(bookFound == null, "Non Existing Book Was returned");
        }
    }
}
