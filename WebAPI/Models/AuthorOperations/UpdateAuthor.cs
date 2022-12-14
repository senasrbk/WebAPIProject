using FluentValidation;
using WebApi.Application.AuthorOprations;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Models.AuthorOperations
{

    public class UpdateAuthor : AbstractValidator<UpdateAuthor>
    {

      public UpdateAuthor()
      {
        RuleFor(x => x.Model.Name).MinimumLength(2)
        .When(x => x.Model.Name != string.Empty);

        RuleFor(x => x.Model.LastName).MinimumLength(2)
        .When(x => x.Model.LastName != string.Empty);

        RuleFor(x=> x.Model.BookId).NotEmpty().GreaterThan(0);
      }
      
    }
}
      