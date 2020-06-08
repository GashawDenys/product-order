using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository cartitems { get; }
        ICustomerRepository customers { get; }
        ICartRepository carts { get; }
        IStoreOrderRepository storeorders { get; }
        void Save();

    }
}
