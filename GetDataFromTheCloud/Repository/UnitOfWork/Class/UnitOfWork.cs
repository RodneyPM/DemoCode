using GetDataFromTheCloud.Models.Db.data;
using GetDataFromTheCloud.Repository.Classes;
using GetDataFromTheCloud.Repository.Interfaces;
using GetDataFromTheCloud.Repository.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetDataFromTheCloud.Repository.UnitOfWork.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UsersRepository = new UsersRepository(_context);
        }

        public IUsersRepository UsersRepository { get; }

        public void Dispose()
        => _context.Dispose();
        

        public int saveChanges()
        => _context.SaveChanges();
    }
}
