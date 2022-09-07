using FluentValidation;
using WebApi.Application.AuthorOprations;
using WebApi.Application.GenreOperations.Commands;

namespace WebAPI.Models.AuthorOperations
{

    public class CreateAuthor : AbstractValidator<CreateAuthor>
    {

      public CreateAuthor()
      {

        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.LastName).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        
      }
      
    }
}