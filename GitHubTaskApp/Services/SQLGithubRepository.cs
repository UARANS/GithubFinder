using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubTaskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHubTaskApp.Services
{
    public class SQLGithubRepository : IRepository<Repo, RepoSearch>
    {
        private readonly ApplicationContext _db;

        public SQLGithubRepository(ApplicationContext context)
        {
            _db = context;
        }

        public async Task AddRangeAsync(IEnumerable<Repo> items)
        {
            await _db.AddRangeAsync(items);
        }

        public async Task<IEnumerable<Repo>> SearchAsync(RepoSearch key)
        {
            var output = await _db.Repos
                .Include(repo => repo.Owner)
                .Where(repo => repo.Name.Contains(key.Name) && repo.Uuid == key.Uuid)
                .OrderBy(repo => repo.Created)
                .ThenBy(repo => repo.UpdatedAt)
                .Take(key.Top)
                .ToListAsync();

            return output;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
