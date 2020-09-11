using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Initial Catalog=Database;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Osnv> Osnvs { set; get; }
        public virtual DbSet<Dop> Dops { set; get; }
    }
}
