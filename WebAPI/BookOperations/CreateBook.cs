using System;
using System.Linq;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using AutoMapper;

namespace WebAPI.BookOperations
{
    public class CreateBook{
       private readonly BookStoreDbContext _dbContext;
       private readonly IMapper _mapper;

       public CreateBookModel Model { get; set; }

        public CreateBook( BookStoreDbContext context,IMapper mapper){
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);

            if( book is not null){
                throw new InvalidOperationException("Kitap zaten var");
            }


            book = _mapper.Map<Book>(Model);
            // book = new Book();
            // book.Title = Model.Title;
            // book.PublishDate = Model.PublishDate;
            // book.PageCount = Model.PageCount;
            // book.GenreId = Model.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();


        }

        public class CreateBookModel{
            public string Title { get; set; }

            public int GenreId { get; set; }
            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }


        }

    }
}