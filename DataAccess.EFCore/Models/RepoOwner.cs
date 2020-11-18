using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.EFCore.Models
{
    public class RepoOwner
    {
        [Key]
        public int OwnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [JsonPropertyName("avatar_url")]
        [StringLength(2000)]
        public string AvatarUrl { get; set; }
    }
}
