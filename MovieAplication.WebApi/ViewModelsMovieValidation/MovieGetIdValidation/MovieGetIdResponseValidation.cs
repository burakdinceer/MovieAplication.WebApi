using FluentValidation;
using MovieAplication.WebApi.ViewModels;

namespace MovieAplication.WebApi.ViewModelsMovieValidation.MovieGetIdValidation
{
    public class MovieGetIdResponseValidation : AbstractValidator<MovieGetIdResponse>
    {
        public MovieGetIdResponseValidation()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
