﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbModelContainer : DbContext
    {
        public DbModelContainer()
            : base("name=DbModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Manager> ManagerSet { get; set; }
        public virtual DbSet<Content> ContentSet { get; set; }
        public virtual DbSet<Client> ClientSet { get; set; }
        public virtual DbSet<Item> ItemSet { get; set; }
    }
}