using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using ZUMOAPPNAMEService.DataObjects;

namespace ZUMOAPPNAMEService.Models
{
    public class ZUMOAPPNAMEContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "MS_TableConnectionString";

        public ZUMOAPPNAMEContext() : base(connectionStringName)
        {
        } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Substation> Substations { get; set; }

        public DbSet<DecommissionData> Decommissions { get; set; }

        public DbSet<User> Users { get; set; }
    }

    
}
