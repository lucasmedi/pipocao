using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
	public class ComentarioMap : ClassMap<Comentario>
	{
		public ComentarioMap()
		{
			Id(x => x.Id)
				.GeneratedBy.Identity();

			Map(x => x.Data);

			Map(x => x.Gostei);

			Map(x => x.Texto)
				.Not.Nullable()
				.Length(4000);

            Map(x => x.Nota)
				.Check("ck_comentarios_nota_range");

			References<Filme>(x => x.Filme);

			References<Usuario>(x => x.Usuario);
		}
	}
}