﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyRestfullApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class MyRestfullAppEntities : DbContext
    {
        #region Constructors

        public MyRestfullAppEntities()
            : base("name=MyRestfullAppEntities")
        {
        }

        #endregion Constructors

        #region Properties

        public virtual DbSet<User> User
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        #endregion Methods
    }
}