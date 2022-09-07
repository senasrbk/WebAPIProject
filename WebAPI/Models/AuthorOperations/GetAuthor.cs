using FluentValidation;
using WebApi.Application.AuthorOprations.Queries;
using WebApi.Application.GenreOperations.Queries;

namespace WebApi.Models.AuthorOperations
{

    public class GetAuthorDetail : AbstractValidator<GetAuthorDetailQuery>
    {

      public GetAuthorDetail()
      {
        RuleFor(x => x.AuthorId).GreaterThan(0);
      }
        
      
    }
}