﻿using Database.HotContext.DataSeeds;
using Date.Models.Entities.Log;
using Date.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database.HotContext
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(DbContextOptions opt, IConfiguration config) :base(opt) { _configuration = config; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserRoleSeed());
            modelBuilder.ApplyConfiguration(new UserSeed(_configuration));
        }

        public DbSet<LogEntity> LogTable { get; set; }
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<UserRoleEntity> UserRolesTable { get; set; }
    }
}