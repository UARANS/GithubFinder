using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("forks_count")]
        public int ForksCount { get; set; }

        [JsonPropertyName("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
        public RepoOwner Owner { get; set; }
        public Guid Uuid { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
    public class RepoOwner
    {
        [Key]
        public int OwnerId { get; set; }

        [Required]
        public string Login { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
