using DAL.Infrastructure;

namespace DAL.Classes
{
	public interface IUsuario : IEntityKey<int>
	{
		string Nome { get; set; }
		string Email { get; set; }
	}
}