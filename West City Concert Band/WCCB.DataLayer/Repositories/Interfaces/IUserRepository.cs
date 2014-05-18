using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool CheckPassword(Guid id, string password);
    }
}
