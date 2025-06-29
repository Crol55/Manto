﻿using BoardsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardsService.Data
{
    public class BoardsDbContext: DbContext
    {
        public BoardsDbContext(DbContextOptions<BoardsDbContext> options): 
            base(options)
        {
            
           
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardList> BoardLists { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<BoardRoles> BoardRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Project>()
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<BoardList>()
                .Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME");

            modelBuilder.Entity<BoardMember>()
                .Property(x => x.JoiningDate)
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("DATETIME");
        }
    }
}
