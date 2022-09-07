using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebAPI.Model.GenreOperations
{

    public class CreateGenre : AbstractValidator<CreateGenreCommand>
    {

      public CreateGenre()
      {
        RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
        
      }
      
    }
}