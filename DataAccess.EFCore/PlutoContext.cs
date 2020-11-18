using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccess.EFCore.Models;

namespace DataAccess.EFCore
{
    public class PlutoContext : DbContext
    {
        public PlutoContext(DbContextOptions<PlutoContext> options)
            : base(options)
        {
        }

        public DbSet<Repo> Repos { get; set; }
        public DbSet<RepoOwner> RepoOwners { get; set; }
    }

}
