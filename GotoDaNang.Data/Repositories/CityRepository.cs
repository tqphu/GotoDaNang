using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
    }

    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
