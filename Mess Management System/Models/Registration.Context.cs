﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mess_Management_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class messEntities : DbContext
    {
        public messEntities()
            : base("name=messEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<mess_member> mess_member { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<manager> managers { get; set; }
        public virtual DbSet<MonthlyCost> MonthlyCosts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
