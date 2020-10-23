using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubTaskApp.Models
{
    public class Repo
    {
        public int RepoId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        [Required]
        public DateTime Updated_at { get; set; }
        public int Forks_count { get; set; }
        public int Stargazers_count { get; set; }
        public string Html_url { get; set; }
        public RepoOwner Owner { get; set; }
        public Guid Uuid { get; set; }
        public DateTime Created { get; set; }
    }
    public class RepoOwner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        public string Login { get; set; }
        public string Avatar_url { get; set; }
    }
}
