using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MithunKeyNinjaTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.DbConnection
{
    public class Context:DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public IConfigurationRoot Configuration { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configuration.Build();
            string conStr = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(conStr))
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IIVRUH6; Database=ReMIS; uid=sa; pwd=mithun; MultipleActiveResultSets=true; Trusted_Connection=True; Connection Timeout=100;Integrated Security=false");
            }
            else
            {
                optionsBuilder.UseSqlServer(conStr);
            }
        }

        public DbSet<Rider> Rider { get; set; }
        public DbSet<Jobs> Jobs { get; set; }

    }
}
