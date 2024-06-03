using Book_EF.Data;

namespace Book_EF.Models
{
    public class BookDAL
    {
        ApplicationDbContext db;

        public BookDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Book> GetBooks()
        {
            // return db.Books.ToList();

            var result = (from b in db.Books
                          select b).ToList();
            return result;
        }
        public Book GetBookById(int id)
        {
           // var result = db.Books.Where(x=> x.Id == id).SingleOrDefault();
           // return result;

            var result = (from b in db.Books
                         where b.Id == id
                         select b).SingleOrDefault();
            return result;
        }
        public int AddBook (Book book)
        {
            int res = 0;
            db.Books.Add(book);
            res = db.SaveChanges();
            return res;
        }

        public int UpdateBook(Book book)
        {
          //  var result = db.Books.Where(x=> x.Id == book.Id).SingleOrDefault();
          //  return result;

            int res = 0;

            var result = (from b in db.Books
                         where b.Id == book.Id
                         select b).SingleOrDefault();

            if(result != null)
            {
                result.Name = book.Name;
                result.Author = book.Author;
                result.Price = book.Price;
                res = db.SaveChanges();
            }
            return res;
        }

        public int DeleteBook(int id)
        {
            //  var result = db.Books.Where(x=> x.Id == id).SingleOrDefault();
            //  return result;

            int res = 0;

            var result = (from b in db.Books
                         where b.Id == id
                         select b).FirstOrDefault();
            if(result != null)
            {
                db.Books.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
