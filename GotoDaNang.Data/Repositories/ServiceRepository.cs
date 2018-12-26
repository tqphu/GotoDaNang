using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
    }

    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
