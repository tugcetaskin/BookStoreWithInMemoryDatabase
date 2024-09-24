using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBooksQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<BookViewModel> Handle()
        {
            var list = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in list){
                vm.Add(new BookViewModel(){
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
                    Genre = ((GenreEnum)book.GenreId).ToString()
                });
            }
            return vm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set;}
        public int PageCount { get; set;}
        public string PublishDate {get; set;}
        public string Genre { get; set;}
    }
}