using System;

namespace GotoDaNang.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        GotoDaNangDbContext Init();
    }
}