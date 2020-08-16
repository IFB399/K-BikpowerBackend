﻿using System.Data.Entity;
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

        private const string connectionStringName = "Name=tcp:kbikpower.database.windows.net,1433;Initial Catalog=K-bikpower;User Id=warptech@kbikpower;Password=grap3boi#";

        public ZUMOAPPNAMEContext() : base(connectionStringName)
        {
        } 

        public DbSet<Assets> Assets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }

}
