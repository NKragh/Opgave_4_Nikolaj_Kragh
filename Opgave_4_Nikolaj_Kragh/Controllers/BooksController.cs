using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opgave_1_Nikolaj_Kragh;

namespace Opgave_4_Nikolaj_Kragh.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book("Bogens Titel", "Johan Nilesen", 123, "12345qwertasd"),
            new Book("Titel af bogen", "Nikolaje Krak", 321, "zxcvbnmlkjhgf"),
            new Book("Cool Title", "Jonass Rassmussen", 542, "uyitorpeldkfj"),
            new Book("Original Title", "Copywriter", 999, "qmwnebrvtcyux"),
            new Book("Original Titel", "Kopiskriver", 10, "hgjfkdl657483"),
        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return BookList;
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{isbn13}")]
        public Book Get(string isbn13)
        {
            return BookList.Find(c => c.Isbn13 == isbn13);
        }

        // POST: api/Books
        [HttpPost]
        [Route("{isbn13}")]
        public void Post([FromBody] Book value)
        {
            BookList.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut]
        [Route("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book b = Get(isbn13);
            if (value != null)
            {
                b.Titel = value.Titel;
                b.Forfatter = value.Forfatter;
                b.Sidetal = value.Sidetal;
                b.Isbn13 = value.Isbn13;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book b = Get(isbn13);
            if (b != null)
            {
                BookList.Remove(b);
            }
        }
    }
}
