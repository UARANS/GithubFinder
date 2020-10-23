using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GitHubTaskApp.Models;
using System.Globalization;

namespace GitHubTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ReposController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Repo>>> GetRepos(string name, string guid)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(guid))
            {
                return BadRequest();
            }

            Guid uuid = new Guid(guid.Replace("\"", ""));

            var repos = await _context.Repos
                .Include(repo => repo.Owner)
                .Where(repo => repo.Name.Contains(name) && repo.Uuid == uuid)
                .OrderByDescending(repo => repo.Created)
                .ThenByDescending(repo => repo.Updated_at)
                .Take(10)
                .ToListAsync();

            if (repos.Count <= 0)
            {
                return NotFound();
            }

            return repos;
        }

        [HttpPost]
        public async Task<ActionResult> PostRepos(List<Repo> repos)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            DateTime now = DateTime.Now;
            Guid guid = Guid.NewGuid();

            foreach (Repo repo in repos)
            {
                repo.Created = now;
                repo.Uuid = guid;
            }

            _context.Repos.AddRange(repos);
            await _context.SaveChangesAsync();
            return Ok(guid);
        }
    }
}
