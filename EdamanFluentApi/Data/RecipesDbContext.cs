﻿using EdamanFluentApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EdamanFluentApi.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
        }

        public DbSet<Result> Results { get; set; }
        public DbSet<Hit> Hits { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Digest> Digests { get; set; }
        public DbSet<Total> Totals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            //modelBuilder.Entity<Result>().HasKey(r => r.Id);
            //modelBuilder.Entity<Hit>().HasKey(h => h.Id);
            //modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            //modelBuilder.Entity<Digest>().HasKey(d => d.Id);
            //modelBuilder.Entity<Total>().HasKey(t => t.Id);

            //// Configure foreign keys
            //modelBuilder.Entity<Hit>().HasOne(h => h.Result).WithMany(r => r.Hits).HasForeignKey(h => h.ResultId);
            //modelBuilder.Entity<Recipe>().HasOne(r => r.Hit).WithOne(h => h.Recipe).HasForeignKey<Hit>(h => h.RecipeId);
            //modelBuilder.Entity<Digest>().HasOne(d => d.Recipe).WithMany(r => r.Digest).HasForeignKey(d => d.RecipeId);
            //modelBuilder.Entity<Total>().HasOne(t => t.Recipe).WithMany(r => r.Totals).HasForeignKey(t => t.RecipeId);

            // Configure array properties
            modelBuilder.Entity<Recipe>().Property(r => r.Cautions).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            );

            modelBuilder.Entity<Recipe>().Property(r => r.IngredientLines).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            );
        }
    }
}