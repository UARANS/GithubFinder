using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.EFCore;
using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.EFCore.Repositories
{
    public class GithubRepository : Repository<Repo>, IGithubRepository
    {
        public GithubRepository(PlutoContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Repo>> GetLatestRepos(RepoSearch key, int count = 10)
        {
            var output = await PlutoContext.Repos
                .Include(repo => repo.Owner)
                .Where(repo => repo.Name.Contains(key.Name) && repo.Uuid == key.Uuid)
                .OrderBy(repo => repo.Created)
                .ThenBy(repo => repo.UpdatedAt)
                .Take(count)
                .ToListAsync();

            return output;
        }

        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}
