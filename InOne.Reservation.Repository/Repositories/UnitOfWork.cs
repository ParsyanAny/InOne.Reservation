using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using InOne.Reservation.Repository.Interfaces;
using InOne.Reservation.DataAccess;

namespace InOne.Reservation.Repository.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private bool disposed;
        private readonly Dictionary<string, object> repositories;

        public UnitOfWork(ApplicationContext _dbContext)
        {
            this._context = _dbContext;
            repositories = new Dictionary<string, object>();
        }

        public IFurnitureRepository FurnitureRepository => Repository<FurnitureRepository>();
        public IBookingRepository BookingRepository => Repository<BookingRepository>();
        public IRoomRepository RoomRepository => Repository<RoomRepository>();
        public IUserRepository UserRepository => Repository<UserRepository>();

        private TRepository Repository<TRepository>()
        {
            var type = typeof(TRepository);
            if (!repositories.ContainsKey(type.Name))
            {
                var obj = Activator.CreateInstance(type, _context);
                repositories.Add(type.Name, obj);
            }
            return (TRepository)repositories[type.Name];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            disposed = true;
        }
    }
}