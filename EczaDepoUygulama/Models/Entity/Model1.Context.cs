﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EczaDepoUygulama.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EczaDepoUygulamaEntities : DbContext
    {
        public EczaDepoUygulamaEntities()
            : base("name=EczaDepoUygulamaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<birimtbl> birimtbl { get; set; }
        public virtual DbSet<ilactbl> ilactbl { get; set; }
        public virtual DbSet<kategorilertbl> kategorilertbl { get; set; }
        public virtual DbSet<markalartbl> markalartbl { get; set; }
        public virtual DbSet<musterilertbl> musterilertbl { get; set; }
        public virtual DbSet<satislartbl> satislartbl { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
