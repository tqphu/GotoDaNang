using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data.Repositories
{
   public interface IAdminRepository : IRepository<Admin>
    {
    }

    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
