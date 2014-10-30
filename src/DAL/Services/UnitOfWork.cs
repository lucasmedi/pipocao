using System;
using System.Data;
using DAL.Infrastructure;
using NHibernate;

namespace DAL.Services
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ISession _sessionFactory;
		private readonly ITransaction _transaction;

		public ISession Session { get; private set; }

		public UnitOfWork(ISession sessionFactory)
		{
			Session.FlushMode = FlushMode.Auto;
			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Commit()
		{
			if (!_transaction.IsActive)
				throw new InvalidOperationException("Não há transação ativa.");
			
			_transaction.Commit();
		}

		public void Rollback()
		{
			if (_transaction.IsActive)
				_transaction.Rollback();
		}

		public void Dispose()
		{
			if (Session.IsOpen)
				Session.Close();
		}
	}
}