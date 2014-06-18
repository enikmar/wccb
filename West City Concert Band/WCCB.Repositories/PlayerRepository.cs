using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Helpers;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Repositories.Interfaces;
using WCCB.Models;

namespace WCCB.DataLayer.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        
        
    }
}
