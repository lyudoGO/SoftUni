﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.ShowDataFromTables
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdsEntities : DbContext
    {
        public AdsEntities()
            : base("name=AdsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdStatus> AdStatuses { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
