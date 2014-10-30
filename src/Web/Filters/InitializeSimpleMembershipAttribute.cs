using System;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Web.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
	{
		private static SimpleMembershipInitializer _initializer;
		private static object _initializerLock = new object();
		private static bool _isInitialized;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
		}

		private class SimpleMembershipInitializer
		{
			public SimpleMembershipInitializer()
			{
				try
				{
					if (!WebSecurity.Initialized)
					{
						WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Usuarios", "Id", "Email", autoCreateTables: true);
					}
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException("Erro na inicialização do autenticador. Contate o administrador.", ex);
				}
			}
		}
	}
}