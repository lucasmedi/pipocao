using System;
using DAL.Classes;

namespace DAL.Entities
{
	public class Comentario : IComentario
	{
		public virtual int Id { get; set; }
		public virtual DateTime Data { get; set; }
		public virtual bool Gostei { get; set; }
		public virtual string Texto { get; set; }
        public virtual int Nota { get; set; }

		public virtual int FilmeId { get; set; }
		public virtual IFilme Filme { get; set; }

		public virtual int UsuarioId { get; set; }
		public virtual IUsuario Usuario { get; set; }
	}
}