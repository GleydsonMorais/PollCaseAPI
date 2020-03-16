using Microsoft.EntityFrameworkCore;
using PollCase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollCase.Data.Contexts
{
    public class PollCaseDbContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Options> Options { get; set; }

        public PollCaseDbContext(DbContextOptions<PollCaseDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=GGUEDESM10\\SQLEXPRESS;Database=PollCase;Trusted_Connection=True;MultipleActiveResultSets=true",
                    x => x.MigrationsHistoryTable("__efmigrationshistory"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ~~ Poll ~~
            modelBuilder.Entity<Poll>(i =>
            {
                i.ToTable("Poll");
                i.HasKey(x => x.poll_id);

                i.HasMany(x => x.Options)
                .WithOne(x => x.Poll)
                .HasForeignKey(x => x.poll_id);
            });

            modelBuilder.Entity<Options>(i =>
            {
                i.ToTable("Options");
                i.HasKey(x => x.option_id);

                i.HasOne(x => x.Poll)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.poll_id);
            });
            #endregion
        }
    }
}
