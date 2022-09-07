using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebAPI.Model.GenreOperations
{

    public class DeleteGenre : AbstractValidator<DeleteGenreCommand>
    {

      public DeleteGenre()
      {
        RuleFor(x => x.GenreId).GreaterThan(0);
        
      }
      
    }
}