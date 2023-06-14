﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cart.Models
{
    public partial class CartContext : DbContext
    {
        public CartContext()
        {
        }

        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<userCart> userCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<item>(entity =>
            {
                entity.Property(e => e.itemId).ValueGeneratedNever();
            });

            modelBuilder.Entity<userCart>(entity =>
            {
                entity.Property(e => e.userID).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}