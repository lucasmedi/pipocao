using System;
using DAL.Infrastructure;

namespace DAL.Classes
{
	public interface IComentario : IEntityKey<int>
	{
		DateTime Data { get; set; }
		bool Gostei { get; set; }
		string Texto { get; set; }
		int Nota { get; set; }

		int FilmeId { get; set; }
		IFilme Filme { get; set; }

		int UsuarioId { get; set; }
		IUsuario Usuario { get; set; }
	}
}