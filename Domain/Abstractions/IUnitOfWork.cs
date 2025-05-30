﻿using Domain.Product;

namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        Task CommitAsync();
        Task RollbackAsync();
    }
}
