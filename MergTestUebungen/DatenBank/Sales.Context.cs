﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MergTestUebungen.DatenBank
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SalesEntities : DbContext
    {
        public SalesEntities()
            : base("name=SalesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<currencies> currencies { get; set; }
        public virtual DbSet<customer_managers> customer_managers { get; set; }
        public virtual DbSet<customers> customers { get; set; }
        public virtual DbSet<orderdetails> orderdetails { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<custstats> custstats { get; set; }
        public virtual DbSet<myorders> myorders { get; set; }
        public virtual DbSet<russia> russia { get; set; }
    }
}
