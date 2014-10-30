using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
	public class UsuarioMap : ClassMap<Usuario>
	{
		public UsuarioMap()
		{
			Id(x => x.Id)
				.GeneratedBy.Identity();

			Map(x => x.Nome)
				.Not.Nullable()
				.Length(255);

			Map(x => x.Email)
				.Not.Nullable()
				.Length(255);
		}
	}
}