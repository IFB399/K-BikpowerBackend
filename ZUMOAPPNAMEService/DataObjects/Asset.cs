using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class Asset : EntityData
    {
        public string Substation_code { get; set; }

        public string Plant_number { get; set; }

        public int Asset_eq_no { get; set; }

        public string Eq_status { get; set; }

        public string Serial_number { get; set; }

        public string Modifier_code { get; set; }

        public int Location_equipment_number { get; set; }

        public string Component_code { get; set; }

        //public DateTime Warranty_date { get; set; }

        public int Equipment_age { get; set; }// needs auto timer

        public string Stock_code { get; set; }

        public string Po_no { get; set; }

        public int Rated_volts { get; set; }

        public int Nominal_volts { get; set; }

        public string Manufacturer_name { get; set; }

        public string Manufacturer_type { get; set; }

        public string Specification_title { get; set; }

        public string Specification_no { get; set; }

        public string Specification_item_no { get; set; }

        public string Last_install_date { get; set; }

        public string Equipment_class { get; set; }

        public string Equimpent_class_decription { get; set; }

        public string Status { get; set; } //recently added

        public string Decommission_form_id { get; set; } //idk what im doing really

        public string Commission_form_id { get; set; } //stores the latest commission form id?

        public string Modified_by { get; set; } //keeps a record of the user that last modified it?
    }
}