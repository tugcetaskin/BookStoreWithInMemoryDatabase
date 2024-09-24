using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookById
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _context;
        public GetByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public GetByIdViewModel Handle(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
                return null;
            
            var result = new GetByIdViewModel(){
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy")
            };

            return result;
        }
    }

    public class GetByIdViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}