﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Andreeva_TZv2.BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DayAndNightEntities : DbContext
    {
        public DayAndNightEntities()
            : base("name=DayAndNightEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<blocking> blocking { get; set; }
        public virtual DbSet<booking_history> booking_history { get; set; }
        public virtual DbSet<borrow_room> borrow_room { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<info_room> info_room { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<status_room> status_room { get; set; }
        public virtual DbSet<status_user> status_user { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<type_room> type_room { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}
