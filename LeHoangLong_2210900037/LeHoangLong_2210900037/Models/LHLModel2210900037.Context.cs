﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeHoangLong_2210900037.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LeHoangLong_2210900037Entities : DbContext
    {
        public LeHoangLong_2210900037Entities()
            : base("name=LeHoangLong_2210900037Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Lhl_Sach> Lhl_Sach { get; set; }
        public virtual DbSet<Lhl_TacGia> Lhl_TacGia { get; set; }
    }
}