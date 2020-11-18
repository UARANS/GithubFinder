using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.EFCore.Models;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces
{
    public interface IGithubRepository : IRepository<Repo>
    {
        Task<IEnumerable<Repo>> GetLatestRepos(RepoSearch key, int count = 10);
    }
}
