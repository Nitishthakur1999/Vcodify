using Microsoft.EntityFrameworkCore;

namespace VCodify.DatabaseEntities
{
    public class VcodifyContext : DbContext
    {
        public VcodifyContext(DbContextOptions<VcodifyContext> options) : base(options)
        {

        }

        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<Users> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //    {
        //        entity.SetTableName(entity.GetTableName().ToSnakeCase());

        //        foreach (var property in entity.GetProperties())
        //            property.SetColumnName(property.Name.ToSnakeCase());

        //        foreach (var key in entity.GetKeys())
        //            key.SetName(key.GetName().ToSnakeCase());

        //        foreach (var key in entity.GetForeignKeys())
        //            key.SetConstraintName(key.GetConstraintName().ToSnakeCase());

        //        foreach (var index in entity.GetIndexes())
        //            index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
        //    }

        //}
    }
}
