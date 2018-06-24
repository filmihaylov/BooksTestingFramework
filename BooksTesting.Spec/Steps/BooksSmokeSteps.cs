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
    public class BooksSmokeSteps
    {
        private HttpClientContext _clientContext;
        private static ConcurrentBag<BookDTO> _booksList = SharedData.BooksList;
        private static ConcurrentBag<BookDTO> allBooks = SharedData.AllBooks;
        private static ConcurrentBag<BookDTO> allBooksTitleSearch = SharedData.AllBooksTitleSearch;

        public BooksSmokeSteps(HttpClientContext clientContext)
        {
            this._clientContext = clientContext;
        }

        [Given(@"I have books")]
        public async Task GivenIHaveBooks(Table table)
        {
            var book = table.CreateInstance<BookDTO>();

            var response = await this._clientContext.Client.Post(Endpoints.BooksEndpoint, book);
            Assert.True(response.IsSuccessStatusCode, "Book was not added to Post Book Endpoint");
            // book aded to deleteion step
            _booksList.Add(book);
        }

        [Then(@"The book should be added with")]
        public async Task ThenTheBookShouldBeAddedWith(Table table)
        {
            // fails due to author null
            var book = table.CreateInstance<BookDTO>();
            var response = await this._clientContext.Client.Get(Endpoints.IdBookEndpoint(book.Id));
            Assert.True(response.IsSuccessStatusCode, "Book Was not Present");
            var myBook = JsonConvert.DeserializeObject<BookDTO>(response.Content.ReadAsStringAsync().Result);
            Assert.True(myBook != null, "No book was found with the present properties");
            Assert.Equal(book.Title, myBook.Title);
            Assert.Equal(book.Author, myBook.Author);
            Assert.Equal(book.Description, myBook.Description);
            Assert.Equal(book.Id, myBook.Id);
        }

        [Given(@"I update a book with values")]
        public async Task GivenIUpdateABookWithValues(Table table)
        {
            var book = table.CreateInstance<BookDTO>();
            var response = await this._clientContext.Client.Put(Endpoints.UpdateBookEndpoint(book.Id), book);
            Assert.True(response.IsSuccessStatusCode, "Book Was not Updated");
        }

        [Then(@"The book should be Updated with values")]
        public async Task ThenTheBookShouldBeUpdatedWithValues(Table table)
        {
            // fails due to description not updated
            var book = table.CreateInstance<BookDTO>();
            var response = await this._clientContext.Client.Get(Endpoints.IdBookEndpoint(book.Id));
            Assert.True(response.IsSuccessStatusCode, "Book Was not Present after Update");
            var myBook = JsonConvert.DeserializeObject<BookDTO>(response.Content.ReadAsStringAsync().Result);
            Assert.True(myBook != null, "No book was found with the present properties");
            Assert.Equal(book.Title, myBook.Title);
            Assert.Equal(book.Author, myBook.Author);
            Assert.Equal(book.Description, myBook.Description);
            Assert.Equal(book.Id, myBook.Id);
        }
        [Given(@"I delete a book with id '(.*)'")]
        public async Task GivenIDeleteABookWithId(int id)
        {
            var response = await this._clientContext.Client.Delete(Endpoints.DeleteBookEndpoint(id));
            Assert.True(response.IsSuccessStatusCode, "Book Was not Deleted");
        }

        [Then(@"The book should be Deleted with id '(.*)'")]
        public async Task ThenTheBookShouldBeDeletedWithId(int id)
        {
            var response = await this._clientContext.Client.Get(Endpoints.IdBookEndpoint(id));
            Assert.True(response.StatusCode.Equals(HttpStatusCode.NotFound), "Book Was not Present after Update");
            var message = JsonConvert.DeserializeObject<MessageDTO>(response.Content.ReadAsStringAsync().Result);
            Assert.True(message.Message.Contains("not found!"), "Book should be deleted, but was found");
        }


        [Given(@"I Get All Books")]
        public async Task GivenIGetAllBooks()
        {
            var response = await this._clientContext.Client.Get(Endpoints.BooksEndpoint);
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooks = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            foreach(var book in localallBooks)
            {
                if (!allBooks.Contains(book))
                {
                    allBooks.Add(book);
                }
            }
        }

        [Then(@"All Books should be received")]
        public void ThenAllBooksShouldBeReceived()
        {
            Assert.True(allBooks.Count > 10, "books are returned");
        }

        [Given(@"I search for the books title '(.*)'")]
        public async Task GivenISearchForTheBooksTitle(string value)
        {
            var response = await this._clientContext.Client.Get(Endpoints.SearchBookEndpoint(value));
            Assert.True(response.IsSuccessStatusCode, "All Books were returned");
            var localallBooksTitleSearch = JsonConvert.DeserializeObject<List<BookDTO>>(response.Content.ReadAsStringAsync().Result);
            foreach(var element in localallBooksTitleSearch)
            {
                if (!allBooksTitleSearch.Contains(element))
                {
                    allBooksTitleSearch.Add(element);
                }
            }
        }

        [Then(@"the book should be found")]
        public void ThenTheBookShouldBeFound(Table table)
        {
            var list = allBooksTitleSearch.ToList();
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
