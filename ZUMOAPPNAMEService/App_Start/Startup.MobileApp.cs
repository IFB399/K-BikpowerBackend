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
            Database.SetInitializer<ZUMOAPPNAMEContext>(null);

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
            List<Assets> Asset = new List<Assets>
            {
                new Assets { Id = Guid.NewGuid().ToString(), substation_code = "First Code",plant_number = "plant Number" ,asset_eq_no = 1 ,eq_status = "First" ,serial_number = "1234" ,modifier_code = "123" ,location_equipment_number = 1 ,component_code= "First" , warrantydate = new DateTime(2017, 1, 18),equipment_age = 1 ,stock_code = "First" ,po_no = "First" ,rated_volts = 1 ,nominal_volts=1 ,manufacture_name="First" ,specifiaction_title = "First" ,specification_no= "First" ,specifiaction_item_no = "First" ,last_install_date = "First" ,equipment_class = "First" ,Equimpent_class_decription = "First" , complete = false },
                //new Assets { Id = Guid.NewGuid().ToString(), substation_code = "Second Code", complete = false },
            };

            foreach (Assets Assetlist in Asset)
            {
                context.Set<Assets>().Add(Assetlist);
            }

            base.Seed(context);
        }
    }
}

