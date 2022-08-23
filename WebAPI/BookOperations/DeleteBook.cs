using System;
using System.Linq;

namespace WebAPI.BookOperations
{
    public class DeleteBook{
        private readonly BookStoreDbContext _dbContext;

        public DeleteBook( BookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public int BookId { get; set; }


        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);
            if( book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }



    }

    public class DeleteModel{

    }



}