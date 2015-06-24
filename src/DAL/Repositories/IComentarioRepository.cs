using System.Linq;
using DAL.Classes;
using DAL.Infrastructure;

namespace DAL.Repositories
{
    public interface IComentarioRepository : IPersistRepository<IComentario>, ISearchRepository<IComentario, int>
    {
        IQueryable<IComentario> AllByUser(int id);
        IQueryable<IComentario> FilterByUserAndMovie(int id, int idMovie);
        IQueryable<IComentario> FilterByMovie(int idMovie);
        IQueryable<IComentario> FilterByMovie(string idMovie);

        IComentario[] GetMostValuableMovies();

        void Add(IComentario comentario);
        void Update(IComentario comentario);
        void Delete(IComentario comentario);
    }
}