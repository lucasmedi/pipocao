using DAL.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
	public class FilmeMap : ClassMap<Filme>
	{
		public FilmeMap()
		{
			Id(o => o.Id)
				.GeneratedBy.Identity();

			Map(o => o.TmdbId);

			Map(o => o.Titulo)
				.Not.Nullable()
				.Length(255);

            Map(o => o.Descricao)
                .Length(4000);

            Map(o => o.UrlImagem)
                .Length(255);

            Map(o => o.UrlTrailer)
                .Length(255);

			Map(o => o.TipoMidia)
				.CustomType<int>()
				.Check("ck_filmes_tipoMidia_range");

			References<Usuario>(o => o.Usuario);

			HasMany<Comentario>(o => o.Comentarios)
				.Access.CamelCaseField(Prefix.Underscore)
				.Cascade.AllDeleteOrphan();
		}
	}
}