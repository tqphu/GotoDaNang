using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
