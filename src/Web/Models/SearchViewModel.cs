
namespace Web.Models
{
	public class SearchViewModel
	{
		public FilmeViewModel[] Result { get; set; }

		public string Titulo { get; set; }

		public SearchViewModel()
		{
			Result = new FilmeViewModel[0];
		}
	}
}