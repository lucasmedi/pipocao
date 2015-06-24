using System.Linq;
using DAL.Classes;
using DAL.Infrastructure;

namespace DAL.Repositories
{
    public interface IFilmeRepository : IPersistRepository<IFilme>, ISearchRepository<IFilme, int>
    {
        IQueryable<IFilme> AllByUser(int id);
        IQueryable<IFilme> FilterByUserAndTitle(int id, string titulo);

        void Add(IFilme filme);
        void Update(IFilme filme);
        void Delete(IFilme filme);
    }
}