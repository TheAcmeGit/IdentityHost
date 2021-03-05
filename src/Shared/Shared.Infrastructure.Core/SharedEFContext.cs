﻿using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shared.Infrastructure.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Core
{
    public class SharedEFContext : DbContext
    {
        protected IMediator _mediator;
        //ICapPublisher _capBus;
        public SharedEFContext(DbContextOptions options, IMediator mediator/*, ICapPublisher capBus*/) : base(options)
        {
            _mediator = mediator;
            //_capBus = capBus;
        }

        #region IUnitOfWork 进程内的时间出发
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this);
            return true;
        }
        #endregion
        
        #region ITransaction 分布式事务 使用方式

        //private IDbContextTransaction _currentTransaction;
        //public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        //public bool HasActiveTransaction => _currentTransaction != null;
        //public Task<IDbContextTransaction> BeginTransactionAsync()
        //{
        //    if (_currentTransaction != null) return null;
        //    _currentTransaction = Database.BeginTransaction(_capBus, autoCommit: false);
        //    return Task.FromResult(_currentTransaction);
        //}

        //public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        //{
        //    if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        //    if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        //    try
        //    {
        //        await SaveChangesAsync();
        //        transaction.Commit();
        //    }
        //    catch
        //    {
        //        RollbackTransaction();
        //        throw;
        //    }
        //    finally
        //    {
        //        if (_currentTransaction != null)
        //        {
        //            _currentTransaction.Dispose();
        //            _currentTransaction = null;
        //        }
        //    }
        //}

        //public void RollbackTransaction()
        //{
        //    try
        //    {
        //        _currentTransaction?.Rollback();
        //    }
        //    finally
        //    {
        //        if (_currentTransaction != null)
        //        {
        //            _currentTransaction.Dispose();
        //            _currentTransaction = null;
        //        }
        //    }
        //}


        #endregion


    }
}
