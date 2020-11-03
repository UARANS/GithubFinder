using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubTaskApp.Models
{
    public class RepoSearch
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid? Uuid { get; set; }

        public int Top { get; set; } = 10;
    }
}
