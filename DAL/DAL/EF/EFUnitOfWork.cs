using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private product_orderContext db;
        private CartItemRepository cartitemsRepository;
        private CartRepository cartsRepository;
        private CustomerRepository customersRepository;
        private StoreOrderRepository storeOrdersRepository;

        public EFUnitOfWork(product_orderContext context)
        {
            db = context;
        }
        public ICartItemRepository cartitems
        {
            get
            {
                if (cartitemsRepository == null)
                    cartitemsRepository = new CartItemRepository(db);
                return cartitemsRepository;
            }
        }
        public ICartRepository carts
        {
            get
            {
                if (cartsRepository == null)
                    cartsRepository = new CartRepository(db);
                return cartsRepository;
            }
        }

        public ICustomerRepository customers
        {
            get
            {
                if (customersRepository == null)
                    customersRepository = new CustomerRepository(db);
                return customersRepository;
            }
        }

        public IStoreOrderRepository storeorders
        {
            get
            {
                if (storeOrdersRepository == null)
                    storeOrdersRepository = new StoreOrderRepository(db);
                return storeOrdersRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
