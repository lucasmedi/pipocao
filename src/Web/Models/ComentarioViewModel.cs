using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Classes;

namespace Web.Models
{
	public class ComentarioViewModel : IComentario
	{
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[DisplayName("Data do Comentário")]
		public DateTime Data { get; set; }

		[DisplayName("Gostei")]
		public bool Gostei { get; set; }

		[DisplayName("Comentário")]
		public string Texto { get; set; }

		[DisplayName("Nota")]
		public int Nota { get; set; }

		[ScaffoldColumn(false)]
		public int FilmeId { get; set; }

		[ScaffoldColumn(false)]
		public IFilme Filme { get; set; }

		[ScaffoldColumn(false)]
		public int UsuarioId { get; set; }

		[ScaffoldColumn(false)]
		public IUsuario Usuario { get; set; }

		public static ComentarioViewModel ToModel(IComentario c)
		{
			var comentario = new ComentarioViewModel();
			comentario.Id = c.Id;
			comentario.Data = c.Data;
			comentario.Gostei = c.Gostei;
			comentario.Nota = c.Nota;
			comentario.Texto = c.Texto;

			comentario.FilmeId = c.FilmeId;
			comentario.Filme = c.Filme;

			comentario.UsuarioId = c.UsuarioId;
			comentario.Usuario = c.Usuario;

			return comentario;
		}

		public static void Parse(IComentario comentario, ComentarioViewModel c)
		{
			comentario.Data = c.Data;
			comentario.Gostei = c.Gostei;
			comentario.Nota = c.Nota;
			comentario.Texto = c.Texto;
		}	
	}
}