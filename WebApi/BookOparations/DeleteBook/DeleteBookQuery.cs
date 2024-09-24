using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookQuery
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if(book == null)
                throw new InvalidOperationException("Kitap Bulunamadı!");
            
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}