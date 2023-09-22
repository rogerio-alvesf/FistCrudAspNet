using FistCrudAspNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FistCrudAspNet.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remover convenção de pluralização de nomes de tabelas globalmente
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            // Configurar todas as propriedades de string como varchar
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties()
                    .Where(p => p.ClrType == typeof(string)))
                {
                    property.SetColumnType("varchar(255)"); // Você pode ajustar o tamanho conforme necessário
                }
            }

            // Configurar a propriedade "Id" como chave primária para todas as entidades (opcional)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var idProperty = entity.FindProperty("Id");
                if (idProperty != null && idProperty.ClrType == typeof(int))
                {
                    entity.SetPrimaryKey(idProperty);
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}