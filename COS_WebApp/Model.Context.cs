﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COS_WebApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CanteenOrderingSystemEntities : DbContext
    {
        public CanteenOrderingSystemEntities()
            : base("name=CanteenOrderingSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<account_role> account_role { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<origin> origins { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<products_type> products_type { get; set; }
        public virtual DbSet<sugar_level> sugar_level { get; set; }
    }
}
