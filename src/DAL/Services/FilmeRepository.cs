using System.Linq;
using DAL.Classes;
using DAL.Entities;
using DAL.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DAL.Services
{
	public class FilmeRepository : Repository<IFilme, int>, IFilmeRepository
	{
		public FilmeRepository(ISession session) : base(session) { }

		public IQueryable<IFilme> AllByUser(int id)
		{
			return FilterBy(o => o.Usuario.Id == id, x => x.Titulo);
		}

		public IQueryable<IFilme> FilterByUserAndTitle(int id, string titulo)
		{
			return FilterBy(o => o.Usuario.Id == id && SqlMethods.Like(o.Titulo, string.Format("%{0}%", titulo.Replace(' ', '%'))), x => x.Titulo);
		}

		public void Add(IFilme filme)
		{
			base.Add(Parse(filme));
		}

		public void Update(IFilme filme)
		{
			base.Update(Parse(filme));
		}

		public void Delete(IFilme filme)
		{
			base.Delete(Parse(filme));
		}

		private Filme Parse(IFilme f)
		{
			var filme = new Filme();
			filme.Id = f.Id;
			filme.TmdbId = f.TmdbId;
			filme.Titulo = f.Titulo;
			filme.Descricao = f.Descricao;
			filme.UrlImagem = f.UrlImagem;
			filme.UrlTrailer = f.UrlTrailer;
			filme.TipoMidia = f.TipoMidia;

			if (f.Usuario != null)
				filme.Usuario = f.Usuario;
			else
				filme.Usuario = new Usuario() { Id = f.UsuarioId };

			return filme;
		}
	}
}