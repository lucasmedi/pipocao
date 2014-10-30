using System.Linq;
using DAL.Classes;
using DAL.Entities;
using DAL.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace DAL.Services
{
	public class ComentarioRepository : Repository<IComentario, int>, IComentarioRepository
	{
		public ComentarioRepository(ISession session) : base(session) { }

		public IQueryable<IComentario> AllByUser(int id)
		{
			return FilterBy(o => o.Usuario.Id == id);
		}

		public IQueryable<IComentario> FilterByUserAndMovie(int id, int idMovie)
		{
			return FilterBy(o => o.Id == id && o.Filme.Id == idMovie);
		}

        public IQueryable<IComentario> FilterByMovie(int idMovie)
        {
            return FilterBy(o => o.Filme.Id == idMovie);
        }

        public IQueryable<IComentario> FilterByMovie(string titulo)
        {
            return FilterBy(o => SqlMethods.Like(o.Filme.Titulo, string.Format("%{0}%", titulo.Replace(' ', '%'))));
        }

		public IComentario[] GetMostValuableMovies()
		{
            return base._session.QueryOver<IComentario>()
                .OrderBy(o => o.Nota).Desc
                .List().ToArray();
		}

		public void Add(IComentario filme)
		{
			base.Add(Parse(filme));
		}

		public void Update(IComentario filme)
		{
			base.Update(Parse(filme));
		}

		public void Delete(IComentario filme)
		{
			base.Delete(Parse(filme));
		}

		private Comentario Parse(IComentario c)
		{
			var comentario = new Comentario();
			comentario.Id = c.Id;
			comentario.Data = c.Data;
			comentario.Gostei = c.Gostei;
			comentario.Nota = c.Nota;
			comentario.Texto = c.Texto;

			if (c.Filme != null)
				comentario.Filme = c.Filme;
			else
				comentario.Filme = new Filme() { Id = c.FilmeId };

			if (c.Usuario != null)
				comentario.Usuario = c.Usuario;
			else
				comentario.Usuario = new Usuario() { Id = c.UsuarioId };

			return comentario;
		}
	}
}