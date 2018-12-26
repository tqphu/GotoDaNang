namespace GotoDaNang.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private GotoDaNangDbContext dbContext;

        public GotoDaNangDbContext Init()
        {
            return dbContext ?? (dbContext = new GotoDaNangDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}