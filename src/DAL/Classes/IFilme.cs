using System.Collections.Generic;
using DAL.Helpers;
using DAL.Infrastructure;

namespace DAL.Classes
{
	public interface IFilme : IEntityKey<int>
	{
		int? TmdbId { get; set; }
		string Titulo { get; set; }
		string Descricao { get; set; }
		string UrlImagem { get; set; }
		string UrlTrailer { get; set; }
		TipoMidia TipoMidia { get; set; }

		int UsuarioId { get; set; }
		IUsuario Usuario { get; set; }

		IList<IComentario> Comentarios { get; set; }

		void AddComentario(IComentario comentario, IUsuario usuario);
	}
}