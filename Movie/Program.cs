namespace Movie;

using Movie.Models;
using Movie.DTO;

public class Program
{
    public static void Main(string[] args)
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "Inception", Genre = "Sci-Fi", Rating = 8.8f, ReleaseYear = 2010 },
            new Movie { Title = "The Dark Knight", Genre = "Action", Rating = 9.0f, ReleaseYear = 2008 },
            new Movie { Title = "Interstellar", Genre = "Sci-Fi", Rating = 8.6f, ReleaseYear = 2014 },
            new Movie { Title = "Pulp Fiction", Genre = "Crime", Rating = 8.9f , ReleaseYear = 1994 },
            new Movie { Title = "The Matrix", Genre = "Sci-Fi", Rating = 8.7f , ReleaseYear = 1999 }
        };

        List<ActressPerson> actresses = new List<ActressPerson>
        {
            new ActressPerson { Name = "Ellen Page", Movie = "Inception" },
            new ActressPerson { Name = "Maggie Gyllenhaal", Movie = "The Dark Knight" },
            new ActressPerson { Name = "Carrie-Anne Moss", Movie = "The Matrix" },
            new ActressPerson { Name = "Uma Thurman", Movie = "Pulp Fiction" },
            new ActressPerson { Name = "Anne Hathaway", Movie = "Interstellar" }
        };

        //LINQ

        var moviesQuery = from movie in movies
                          where movie.Rating > 8.7f
                          orderby movie.ReleaseYear descending
                          select movie;


        //Projeção (DTO)

        var moviesQueryProjection = from movie in movies
                                    where movie.Rating > 8.7f
                                    orderby movie.ReleaseYear descending
                                    select new MovieDTO
                                    {
                                        Title = movie.Title,
                                        Info = $"Gênero: {movie.Genre} - Lançamento: {movie.ReleaseYear} - Nota: {movie.Rating}"
                                    };

        //Junção
        var actressQuery = from movie in movies
                           join actress in actresses
                           on movie.Title equals actress.Movie
                           select new ActressMovieDto
                           {
                               Movie = movie.Title,
                               Name = actress.Name,
                               Year = movie.ReleaseYear
                           };
        //Agrupamento
        var actressQueryGroup = from movie in movies
                                join actress in actresses
                                on movie.Title equals actress.Movie
                                group actress by movie.Genre into genreGroup
                                select genreGroup;



        foreach (var genreGroup in actressQueryGroup)
        {
            Console.WriteLine($"Gênero: {genreGroup.Key} - Número de Atrizes: {genreGroup.Count()}  ");
            foreach (var actress in genreGroup)
            {
                Console.WriteLine($" - Atriz: {actress.Name} - Filme: {actress.Movie}");
            }
        }
        // foreach (var movie in actressQuery)
        // {
        //     // Console.WriteLine($"Título: {movie.Title} - Gênero: {movie.Genre} - Nota:{movie.Rating} - Ano de lançamento: {movie.ReleaseYear}");
        //     // Console.WriteLine($"Título: {movie.Title} - Info: {movie.Info}");
        //     Console.WriteLine($"Atriz: {movie.Name} - Filme: {movie.Movie} - Ano de Lançamento: {movie.Year}");
        // }

    }
}