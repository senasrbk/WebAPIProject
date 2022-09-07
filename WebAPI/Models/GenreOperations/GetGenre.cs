using FluentValidation;
using WebApi.Application.GenreOperations.Queries;

namespace WebAPI.Model.GenreOperations
{

    public class GetGenre : AbstractValidator<GetGenreDetailQuery>
    {

      public GetGenreDetail()
      {
        RuleFor(x => x.GenreId).GreaterThan(0);
      }
      
    }
}
        