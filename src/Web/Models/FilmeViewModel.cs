using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Classes;
using DAL.Helpers;
using TMDbLib.Objects.Movies;
using Web.Code;

namespace Web.Models
{
	public class FilmeViewModel : IFilme
	{
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[DisplayName("Id do TMDb")]
		public int? TmdbId { get; set; }

		[DisplayName("Título")]
		public string Titulo { get; set; }

		[DisplayName("Descrição")]
		public string Descricao { get; set; }

		[DisplayName("Url da Imagem")]
		public string UrlImagem { get; set; }

		[DisplayName("Url do Trailer")]
		public string UrlTrailer { get; set; }

		[DisplayName("Tipo de Mídia")]
		public TipoMidia TipoMidia { get; set; }

		[ScaffoldColumn(false)]
		public int UsuarioId { get; set; }

		[ScaffoldColumn(false)]
		public IUsuario Usuario { get; set; }

		[ScaffoldColumn(false)]
		public Movie FilmeTMDb { get; set; }

		[ScaffoldColumn(false)]
		public IList<IComentario> Comentarios { get; set; }

		public void AddComentario(IComentario comentario, IUsuario usuario)
		{
			throw new NotImplementedException();
		}

		public static FilmeViewModel ToModel(IFilme f)
		{
			var filme = new FilmeViewModel();
			filme.Id = f.Id;
			filme.TmdbId = f.TmdbId;
			filme.Titulo = f.Titulo;
			filme.Descricao = f.Descricao;
			filme.UrlImagem = f.UrlImagem;
			filme.UrlTrailer = f.UrlTrailer;
			filme.TipoMidia = f.TipoMidia;

			filme.Comentarios = f.Comentarios;

			filme.UsuarioId = f.UsuarioId;
			filme.Usuario = f.Usuario;

			if (filme.TmdbId.HasValue)
				filme.FilmeTMDb = new TmdbClient().GetMovie(filme.TmdbId.Value);

			return filme;
		}

		public static void Parse(IFilme filme, FilmeViewModel f)
		{
			filme.TipoMidia = f.TipoMidia;
			filme.Descricao = f.Descricao;
			filme.UrlImagem = f.UrlImagem;
			filme.UrlTrailer = f.UrlTrailer;
		}
	}
}