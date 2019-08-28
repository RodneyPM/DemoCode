using GetDataFromTheCloud.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetDataFromTheCloud.Repository.UnitOfWork.Interface
{
   public interface IUnitOfWork : IDisposable
    {
        int saveChanges();
        IUsersRepository UsersRepository { get; }
    }
}
