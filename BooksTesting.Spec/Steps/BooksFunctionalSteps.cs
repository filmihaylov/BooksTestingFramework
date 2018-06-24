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

namespace BooksTesting.Spec
{
    [Binding]
    public class BooksFunctionalSteps
    {
        private HttpClientContext _clientContext;
        private static ConcurrentBag<BookDTO> _booksList = SharedData.BooksList;
        private static ConcurrentBag<BookDTO> allBooks = SharedData.AllBooks;
        private static ConcurrentBag<BookDTO> allBooksTitleSearch = SharedData.AllBooksTitleSearch;
        private static ConcurrentBag<BookDTO> allBooksAuthorSearch = SharedData.AllBooksAuthorSearch;
        private static ConcurrentBag<BookDTO> allBooksIdSearch = SharedData.AllBooksIDSearch;
        private static ConcurrentBag<BookDTO> allBooksDescriptionSearch = SharedData.AllBooksDescriptionSearch;

        public BooksFunctionalSteps(HttpClientContext clientContext)
        {
            this._clientContext = clientContext;
        }
        [Then(@"book should not be present in get all endpoint")]
        public async Task ThenBookShouldNotBePresentInGetAllEndpoint(Table table)
        {
            var book = table.CreateInstance<BookDTO>();
            var response = await this._clientContext.Client.Get(Endpoints.BooksEndpoint);
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooks = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            foreach (var bookInCollection in localallBooks)
            {
                if (bookInCollection.Id == book.Id)
                {
                    Assert.True(false, "deleted book was returned from get all books");
                }
            }
        }
        
        [Then(@"book should not be present in search by title ""(.*)""")]
        public async Task ThenBookShouldNotBePresentInSearchByTitle(string title)
        {
            var response = await this._clientContext.Client.Get(Endpoints.SearchBookEndpoint(title));
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooksTitleSearch = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            Assert.True(localallBooksTitleSearch.Count == 0, "deleted book was returned");
        }

        [Given(@"I search for the books author '(.*)'")]
        public async Task GivenISearchForTheBooksAuthor(string value)
        {
            var response = await this._clientContext.Client.Get(Endpoints.SearchBookEndpointAuthor(value));
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooksAuthorSearch = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            foreach (var element in localallBooksAuthorSearch)
            {
                if (!allBooksAuthorSearch.Contains(element))
                {
                    allBooksAuthorSearch.Add(element);
                }
            }
        }

        [Given(@"I search for the books id '(.*)'")]
        public async Task GivenISearchForTheBooksId(int value)
        {
            var response = await this._clientContext.Client.Get(Endpoints.SearchBookEndpointID(value));
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var bookId = JsonConvert.DeserializeObject<BookDTO>(response.Content.ReadAsStringAsync().Result);

            allBooksIdSearch.Add(bookId);

            
        }

        [Given(@"I search for the books description '(.*)'")]
        public async Task GivenISearchForTheBooksDescription(string value)
        {
            var response = await this._clientContext.Client.Get(Endpoints.SearchBookEndpointDescription(value));
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooksDescriptionSearch = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            foreach (var element in localallBooksDescriptionSearch)
            {
                if (!allBooksDescriptionSearch.Contains(element))
                {
                    allBooksDescriptionSearch.Add(element);
                }
            }
        }

        [Then(@"the book should be found by author")]
        public void ThenTheBookShouldBeFoundByAuthor(Table table)
        {
            var list = allBooksAuthorSearch.ToList();
            // fails due to author null
            var book = table.CreateInstance<BookDTO>();
            var bookFound = list.Find(i => i.Id == book.Id);
            Assert.True(bookFound != null, "No book was returned from search");
            Assert.Equal(book.Title, bookFound.Title);
            Assert.Equal(book.Author, bookFound.Author);
            Assert.Equal(book.Description, bookFound.Description);
            Assert.Equal(book.Id, bookFound.Id);
        }

        [Then(@"the book should be found by id")]
        public void ThenTheBookShouldBeFoundById(Table table)
        {
            var list = allBooksIdSearch.ToList();
            // fails due to author null
            var book = table.CreateInstance<BookDTO>();
            var bookFound = list.Find(i => i.Id == book.Id);
            Assert.True(bookFound != null, "No book was returned from search");
            Assert.Equal(book.Title, bookFound.Title);
            Assert.Equal(book.Author, bookFound.Author);
            Assert.Equal(book.Description, bookFound.Description);
            Assert.Equal(book.Id, bookFound.Id); ;
        }

        [Then(@"the book should be found by description")]
        public void ThenTheBookShouldBeFoundByDescription(Table table)
        {
            var list = allBooksDescriptionSearch.ToList();
            // fails due to author null
            var book = table.CreateInstance<BookDTO>();
            var bookFound = list.Find(i => i.Id == book.Id);
            Assert.True(bookFound != null, "No book was returned from search");
            Assert.Equal(book.Title, bookFound.Title);
            Assert.Equal(book.Author, bookFound.Author);
            Assert.Equal(book.Description, bookFound.Description);
            Assert.Equal(book.Id, bookFound.Id);
        }


    }
}
