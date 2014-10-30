using DAL.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Cache;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace DAL.Infrastructure
{
	public class NHibernateModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ISessionFactory>()
				.ToMethod
				(
					e =>
						Fluently.Configure()
						.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c =>
							c.FromConnectionStringWithKey("DefaultConnection")))
						.Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
						.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Filme>()
							.Conventions.Add(
								PrimaryKey.Name.Is(x => "Id"),
								ForeignKey.EndsWith("Id")
							)
							.Conventions.Add(typeof(ClassConvention))
						)
						.BuildConfiguration()
						.BuildSessionFactory()
				)
				.InSingletonScope();

			Bind<ISession>()
				.ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
				.InRequestScope();
		}

		public class ClassConvention : IClassConvention
		{
			public void Apply(IClassInstance instance)
			{
				instance.Table(Inflector.Inflector.Pluralize(instance.EntityType.Name));
			}
		}
	}
}