﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Portfolio.Controllers;
using Portfolio.Models;

namespace Portfolio.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
	        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Portfolio;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projets>().HasOne(i => i.Categorie);
            modelBuilder.Entity<Projets>().HasOne(y => y.Images);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Projets> Projets { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
    }
}