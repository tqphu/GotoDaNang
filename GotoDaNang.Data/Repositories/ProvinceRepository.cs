using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data.Repositories
{
    public interface IProvinceRepository : IRepository<Province> {


   }
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {

        public ProvinceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
