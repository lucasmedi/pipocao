
namespace DAL.Infrastructure
{
    public interface IEntityKey<TKey>
    {
        TKey Id { get; }
    }
}