using HealthJang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthJang.DAL
{
    public class HealthJangDbContext : DbContext
    {
        public HealthJangDbContext() : base("HealthJangDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}