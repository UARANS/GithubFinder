using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGithubRepository Repos { get; }
        Task<int> Complete();
    }
}
