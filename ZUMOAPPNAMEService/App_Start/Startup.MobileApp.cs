using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;
using Owin;

namespace ZUMOAPPNAMEService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new ZUMOAPPNAMEInitializer());
            Database.SetInitializer(new ZUMOAPPNAMEInitializerSubstation());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<ZUMOAPPNAMEContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class ZUMOAPPNAMEInitializer : CreateDatabaseIfNotExists<ZUMOAPPNAMEContext>
    {
        protected override void Seed(ZUMOAPPNAMEContext context)
        {
            List<Asset> assets = new List<Asset>
            {
                //new Asset { Id = Guid.NewGuid().ToString(), Substation_code = "yeet", Plant_number = "a plant number", Asset_eq_no=666 },
                //new Asset { Id = Guid.NewGuid().ToString(), Substation_code = "a", Plant_number = "b", Asset_eq_no = 12, Eq_status = "c", Serial_number = "d", Modifier_code = "e", Location_equipment_number = 14, Component_code= "f", Warranty_date = new DateTime(2017, 1, 18), Equipment_age = 15, Stock_code = "g", Po_no = "h", Rated_volts = 2, Nominal_volts=3, Manufacturer_name="i", Manufacturer_type="j", Specification_title = "k", Specification_no= "l", Specification_item_no = "m", Last_install_date = "n", Equipment_class = "o", Equimpent_class_decription = "p"},
                //took out warranty date because it prevented adding assets
                new Asset { Id = Guid.NewGuid().ToString(), Substation_code = "a", Plant_number = "b", Asset_eq_no = 12, Eq_status = "c", Serial_number = "d", Modifier_code = "e", Location_equipment_number = 14, Component_code= "f", Equipment_age = 15, Stock_code = "g", Po_no = "h", Rated_volts = 2, Nominal_volts=3, Manufacturer_name="i", Manufacturer_type="j", Specification_title = "k", Specification_no= "l", Specification_item_no = "m", Last_install_date = "n", Equipment_class = "o", Equimpent_class_decription = "p"},
            };
        

            foreach (Asset a in assets)
            {
                context.Set<Asset>().Add(a);
            }

            base.Seed(context);
        }
    }

    public class ZUMOAPPNAMEInitializerSubstation : CreateDatabaseIfNotExists<SubstationContext>
    {
        protected override void Seed(SubstationContext context)
        {
            List<Substations> subs = new List<Substations>
            {
               
                new Substations { Id = Guid.NewGuid().ToString(), Substation_Code = "a", Substation_Name = "brenton Rocks", Area = "idontknow" },
            };


            foreach (Substations s in subs)
            {
                context.Set<Substations>().Add(s);
            }

            base.Seed(context);
        }
    }
}

