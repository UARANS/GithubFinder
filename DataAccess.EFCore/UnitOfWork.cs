using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Repositories;

namespace DataAccess.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Repos = new GithubRepository(_context);
        }

        public IGithubRepository Repos { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
