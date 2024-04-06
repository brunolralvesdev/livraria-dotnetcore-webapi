using livraria_dotnetcore_webapi.Data;
using livraria_dotnetcore_webapi.Entities;
using livraria_dotnetcore_webapi.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace livraria_dotnetcore_webapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookApiContext _bookApiContext;

        public BooksController(BookApiContext context)
        {
            _bookApiContext = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), StatusCodes.Status404NotFound)]
        public IActionResult GetBookById([FromRoute] Guid id)
        {
            var filteredBook = _bookApiContext
                                .Books
                                .FirstOrDefault(x => x.Id == id);

            if (filteredBook is null)
                return NotFound();


            return Ok(filteredBook);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status404NotFound)]
        public IActionResult GetAllBooks()
        {
            var books = _bookApiContext
                        .Books
                        .OrderBy(x => x.Price);
            if (books is null)
                return NotFound();

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = Guid.NewGuid();
            _bookApiContext.Add(book);
            _bookApiContext.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateNameBookById([FromBody]Book book, [FromRoute] Guid id) 
        {
            var filteredBook = _bookApiContext
                                .Books
                                .FirstOrDefault(x => x.Id == id);

            if (filteredBook is null)
                return NotFound(id);

            filteredBook.Title = book.Title;
            filteredBook.Author = book.Author;

            _bookApiContext.Update(filteredBook);
            _bookApiContext.SaveChanges();
             

            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBookById([FromRoute]Guid id) 
        {
            var filteredBook = _bookApiContext
                                .Books
                                .FirstOrDefault(x => x.Id == id);

            if (filteredBook is null)
                return NotFound(id);

            _bookApiContext.Books.Remove(filteredBook);
            _bookApiContext.SaveChanges();

            return NoContent();
        }
    }

}
