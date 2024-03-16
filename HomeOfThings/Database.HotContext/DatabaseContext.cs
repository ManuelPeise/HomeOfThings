using Database.HotContext.DataSeeds;
using Date.Models.Entities;
using Date.Models.Entities.Family;
using Date.Models.Entities.Log;
using Date.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database.HotContext
{
    public class DatabaseContext : DbContext
    {
       
        public DatabaseContext(DbContextOptions opt) : base(opt) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRoleSeed());
            modelBuilder.ApplyConfiguration(new UserRightSeed());
        }

        public DbSet<LogEntity> LogTable { get; set; }
        public DbSet<AppModuleEntity> AppModulesTable { get; set; }
        public DbSet<FamilyEntity> FamilyTable { get; set; }
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<UserRoleEntity> UserRoleTable { get; set; }
        public DbSet<UserRolesEntity> UserRolesTable { get; set; }
        public DbSet<UserRightEntity> UserRightTable { get; set; }
        public DbSet<UserAccessRightEntity> UserAccessRightsTable { get; set; }

    }
}
