using System.Linq;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Web.Code
{
	public class TmdbClient
	{
		private TMDbClient client;

		public TmdbClient()
		{
			this.client = TmdbClientFactory.GetInstance();
		}

		public SearchMovie[] GetMovies(string titulo)
		{
			return client.SearchMovie(titulo, 1).Results.OrderBy(o => o.Title).ToArray();
		}

		public Movie GetMovie(int id)
		{
			var movie = client.GetMovie(id);

			if (!string.IsNullOrEmpty(movie.PosterPath))
				movie.PosterPath = GetImagePath(movie.PosterPath);

			return movie;
		}

		private string GetImagePath(string path)
		{
			return client.GetImageUrl("w300", path).AbsoluteUri;
		}
	}
}