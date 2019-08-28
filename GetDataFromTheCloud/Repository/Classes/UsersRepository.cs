using GetDataFromTheCloud.Models.Db.data;
using GetDataFromTheCloud.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetDataFromTheCloud.Repository.Classes
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {

        }
    }
}
