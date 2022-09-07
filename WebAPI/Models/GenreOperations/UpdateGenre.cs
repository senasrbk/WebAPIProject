using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebAPI.Model.GenreOperations
{

    public class UpdateGenre : AbstractValidator<UpdateGenreCommand>
    {

      public UpdateGenre()
      {
        RuleFor(x => x.Model.Name).MaximumLength(4)
        .When(x => x.Model.Name != string.Empty);

      }
      
    }
}