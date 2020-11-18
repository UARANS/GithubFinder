using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.EFCore.Models
{
    public class Repo
    {
        public int RepoId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }        

        public string Description { get; set; }

        [StringLength(100)]
        public string Language { get; set; }

        [Required]
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("forks_count")]
        public int ForksCount { get; set; }

        [JsonPropertyName("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonPropertyName("html_url")]
        [StringLength(2000)]
        public string HtmlUrl { get; set; }

        [Required]
        public RepoOwner Owner { get; set; }

        public Guid Uuid { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
