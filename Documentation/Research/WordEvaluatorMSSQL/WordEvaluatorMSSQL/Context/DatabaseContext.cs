using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WordEvaluatorMSSQL.Models;

namespace WordEvaluatorMSSQL.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasKey(w => w.Id);
                // Add indexing to the WordSetId and Value columns
                entity.HasIndex(w => new { w.WordSetId, w.Value });

                entity.Property(model => model.Id).HasColumnName("id");
                entity.Property(model => model.WordSetId).HasColumnName("wordset_id");
                entity.Property(model => model.Value).HasColumnName("word").HasMaxLength(100);
            });
        }
    }
}
