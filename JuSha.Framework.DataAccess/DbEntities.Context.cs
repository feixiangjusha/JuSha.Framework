﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace JuSha.Framework.DataAccess
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using JuSha.Framework.Entities;

    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }


        public virtual DbSet<Role> Role { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Func> Func { get; set; }

        public virtual DbSet<FuncType> FuncType { get; set; }

        public virtual DbSet<RoleInFunc> RoleInFunc { get; set; }

    }

}

