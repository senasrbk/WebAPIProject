using FluentValidation;
using WebApi.Application.AuthorOprations;

namespace WebAPI.Models.AuthorOperations
{

    public class DeleteAuthor : AbstractValidator<DeleteAuthor>
    {

      public DeleteAuthor()
      {
        RuleFor(x => x.AuthorID).GreaterThan(0);
      }
      
    }
}