using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Routing;
using DataAccess.EFCore.Interfaces;
using DataAccess.EFCore.Models;

namespace GitHubRepos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReposController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(List<Repo> repos)
        {
            Guid guid = Guid.NewGuid();

            repos.ForEach(repo => repo.Uuid = guid);

            await _unitOfWork.Repos.AddRange(repos);
            await _unitOfWork.Complete();

            return Content(guid.ToString());
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search(RepoSearch key)
        {
            IEnumerable<Repo> repos = await _unitOfWork.Repos.GetLatestRepos(key);
            return new JsonResult(repos);
        }
    }
}
