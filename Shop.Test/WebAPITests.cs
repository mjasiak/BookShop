using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using Shop.Data.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Shop.Test
{
    [TestClass]
    public class WebAPITests
    {
        private HttpClient client;     

        public WebAPITests()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62762");
        }

        [TestMethod]
        public void DoItGetAllBooks()
        {
            IEnumerable<Book> booksList = GetResource("api/books/getallbooks");
            Assert.AreEqual(booksList.Count(), 1000);
        }
        
        [TestMethod]
        public void DoItGetType()
        {
            IEnumerable<Book> booksList = GetResource("api/books/getspecificbookstype?type=1");
            Assert.AreEqual(booksList.First().Type, 1);
        }

        [TestMethod]
        public void DoItGetPartOfTitle()
        {
            var success = true;
            IEnumerable<Book> booksList = GetResource("api/books/getpartoftitle?searchString=tasse");
            foreach(var book in booksList)
            {
                if (book.Name.IndexOf("tAsSe", StringComparison.CurrentCultureIgnoreCase) < 0) success = false;
            }
            Assert.IsTrue(success);
        }
        
        [TestMethod]
        public void DoItGetThroughPublishers()
        {
            var success = true;
            IEnumerable<Book> booksList = GetResource("api/books/getbooksthroughpublishers?searchString=Drug");
            foreach(var book in booksList)
            {
                if (book.Publisher.IndexOf("Drug", StringComparison.CurrentCultureIgnoreCase) < 0) success = false;
            }
            Assert.IsTrue(success);
        }

        public IEnumerable<Book> GetResource(String resource)
        {
            string responseData;
            IEnumerable<Book> booksList;
            HttpResponseMessage response = client.GetAsync(resource).Result;
            if (response.IsSuccessStatusCode)
            {
                responseData = response.Content.ReadAsStringAsync().Result;
                booksList = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseData);
                return booksList;
            }
            else return null;
         }
    }
}
