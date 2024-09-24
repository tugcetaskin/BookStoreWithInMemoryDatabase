using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBooks;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBooks.CreateBooksQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookQuery;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            GetByIdQuery query = new GetByIdQuery(_context);
            var result = query.Handle(id);
            
            if(result == null)
                return BadRequest("Bu id de kitap bulunamadı!");
            return Ok(result);
        }

        // [HttpGet("GetWithQuery")]
        // public Book Get([FromQuery] string id){
        //     var book = _context.Books.Where(x => x.Id ==Convert.ToInt32(id)).FirstOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            CreateBooksQuery query = new CreateBooksQuery(_context);
            try
            {
                query.Model = newBook;
                query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdaetBookModel updatedBook)
        {
            UpdateBookQuery query = new UpdateBookQuery(_context);
            try
            {
                query.Model = updatedBook;
                query.Handle(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            DeleteBookQuery query = new DeleteBookQuery(_context);
            try
            {
                query.Handle(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}