using System.Linq;
using WebApi.DBOperations;
using System.Collections.Generic;
using WebApi.Common;
using AutoMapper;

namespace WebAPI.BookOperations
{
    public class GetBookS
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooks(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle(){
            var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> viewModelBook = new List<BooksViewModel>();
            viewModelBook = _mapper.Map<List<BooksViewModel>>(bookList);

            foreach (var book in bookList)
            {
                viewModelBook.Add(
                    new BooksViewModel{
                        Title=book.Title,
                        Genre = ((GenreEnum)book.GenreId).ToString(),
                        PageCount = book.PageCount,
                        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")                     
                    }
                );
            }

            return viewModelBook;
        }

    }

    public class BooksViewModel{
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
    
}