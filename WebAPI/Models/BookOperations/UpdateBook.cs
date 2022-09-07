using System;
using System.Linq;

namespace WebAPI.Models.BookOperations
{
    public class UpdateBook
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBook(BookStoreDbContext dbContext ){
            _dbContext= dbContext;
        }

        public int BookId { get; set; }

        public BookUpdateViewModel Model { get; set; }

        public void Handle(){
            var updatedBook = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);

            if( updatedBook is null){
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            updatedBook.Title= Model.Title != default ? Model.Title : updatedBook.Title;

            updatedBook.GenreId= Model.GenreId != default ? Model.GenreId : updatedBook.GenreId;

            _dbContext.SaveChanges();
        }

    }

    public class BookUpdateViewModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }
        
    }
    
}