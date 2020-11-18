using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.EFCore.Models
{
    public class RepoSearch
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid? Uuid { get; set; }
    }
}
