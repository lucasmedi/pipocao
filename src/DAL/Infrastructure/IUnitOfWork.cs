using System;

namespace DAL.Infrastructure
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
		void Rollback();
	}
}