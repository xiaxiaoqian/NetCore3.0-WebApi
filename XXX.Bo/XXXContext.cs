using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using XXX.Models.XXXEntities;

namespace XXX.Bo
{
    public class XXXContext:DbContext
    {
        public XXXContext()
        {
        }

        public XXXContext(DbContextOptions<XXXContext> options)
            : base(options)
        {
        }

        public static string ConStr { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Common.AppSettings.GetAppSeting("xxxDB"));
            }
        }
    }
}
