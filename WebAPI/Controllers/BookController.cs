using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using AutoMapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase{


        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks(){
            GetBooks query = new GetBooks(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]    
        public IActionResult GetById(int id){
            BooksViewModelById result;
            try
            {
                GetById query = new GetById(_context,_mapper);
                query.BookId=id;
                result = query.Handle();                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook ){
            CreateBook command = new CreateBook(_context,_mapper);

            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (InvalidOperationException e)
            {
                
                return BadRequest(e.Message);
            }


            return Ok(); 
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] BookUpdateViewModel updatedBook){

            try
            {
                UpdateBook command = new UpdateBook(_context);

                command.BookId =id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){


            try
            {
                DeleteBook command = new DeleteBook(_context);
                command.BookId=id;
                command.Handle();                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }            

            return Ok();
        }

    }


}