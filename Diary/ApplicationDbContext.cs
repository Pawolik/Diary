using Diary.Models.Configurations;
using Diary.Models.Domains;
using System;
using System.Configuration.Provider;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Xml.Linq;

namespace Diary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(GetConnectionStringFromSettings())
        {            
        }

        private static string GetConnectionStringFromSettings()
        {
            string serverAddress = Properties.Settings.Default.serverAddress;
            string serverName = Properties.Settings.Default.serverName;
            string databaseName = Properties.Settings.Default.databaseName;
            string username = Properties.Settings.Default.username;
            string password = Properties.Settings.Default.password;

            return $"Server={serverAddress}\\{serverName};Database={databaseName};User Id={username};Password={password};";
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
        }
    }
}