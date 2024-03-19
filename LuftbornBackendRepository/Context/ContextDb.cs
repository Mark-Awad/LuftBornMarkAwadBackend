using LuftbornBackendCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornBackendRepository.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne<Role>(up => up.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(up => up.RoleID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
