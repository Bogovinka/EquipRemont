//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipRemont
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseREntities : DbContext
    {
        public DatabaseREntities()
            : base("name=DatabaseREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
