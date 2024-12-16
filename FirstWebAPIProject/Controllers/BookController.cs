using FirstWebAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPIProject.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    // Status codes
    // 100-199 - information
    // 200-299 - success
    // 300-399 - redirect
    // 400-499 - user error
    // 500 - server error



    //[HttpGet]
    //public ActionResult<List<Book>> GetBooks() // endpoint
    //{
    //    var books = new List<Book> { 
    //        new Book()
    //        {
    //            Id = 1,
    //            Title = "Test",
    //            Description = "Test",
    //            Pages = 44,
    //            Price = 12
    //        },
    //        new Book()
    //        {
    //            Id = 2,
    //            Title = "Test2",
    //            Description = "Test2",
    //            Pages = 55,
    //            Price = 16
    //        },
    //    };

    //    return Ok(books); // 200 status
    //}

    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById([FromRoute] int id)
    {
        var book = new Book()
        {
            Id = id,
            Title = "Test",
            Description = "Test",
            Pages = 44,
            Price = 12
        };

        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> AddBook([FromBody] Book book)
    {
        // add book to database
        book.Id = new Random().Next(1, 1000000);

        return Created($"/books/{book.Id}", book);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteBook([FromRoute] int id)
    {
        // delete from database

        return Ok(id);
    }

    [HttpPut]
    public ActionResult<Book> UpdateBook([FromBody] Book book)
    {
        // update in database

        return Ok(book);
    }

    [HttpPatch("{id}")]
    public ActionResult<Book> UpdatePrice([FromRoute] int id, [FromBody] int price)
    {
        var book = new Book()
        {
            Id = id,
            Title = "Test",
            Description = "Test",
            Pages = 44,
            Price = price
        };

        return Ok(book);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooksPaged([FromQuery] int skip, [FromQuery] int take)
    {
        var books = new List<Book>(capacity: 1000);
        for (int i = 0; i < 1000; i++)
        {
            var book = new Book()
            {
                Id = i,
                Title = $"Test {i}",
                Description = "Test",
                Pages = new Random().Next(50, 1999),
                Price = new Random().Next(10, 999)
            };
            books.Add(book);
        }

        var pagesBooks = books
            .Skip(skip)
            .Take(take);

        return Ok(pagesBooks);
    }

}
