using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GitHubTaskApp.Models;
using System.Globalization;
using GitHubTaskApp.Services;
using Microsoft.AspNetCore.Routing;

namespace GitHubTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private readonly IRepository<Repo, RepoSearch> _db;

        public ReposController(IRepository<Repo, RepoSearch> db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(List<Repo> repos)
        {
            Guid guid = Guid.NewGuid();

            repos.ForEach(repo => repo.Uuid = guid);

            await _db.AddRangeAsync(repos);
            await _db.SaveAsync();

            return Content(guid.ToString());
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search(RepoSearch key)
        {
            IEnumerable<Repo> repos = await _db.SearchAsync(key);

            return new JsonResult(repos);
        }
    }
}
