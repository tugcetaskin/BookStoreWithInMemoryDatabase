using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookQuery
    {
        public UpdaetBookModel Model {get; set;}
        private readonly BookStoreDbContext _context;
        public UpdateBookQuery(BookStoreDbContext context)
        {
            _context = context;
        }
        
        public void Handle(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if(book == null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı!");
                
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;

            _context.SaveChanges();
        }
        public class UpdaetBookModel
        {
            public string Title {get; set;}
            public DateTime PublishDate {get; set;}
            public int GenreId {get; set;}
            public int PageCount {get; set;}

        }
    }
}