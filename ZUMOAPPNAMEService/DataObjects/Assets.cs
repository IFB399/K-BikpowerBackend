using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class Assets : EntityData
    {
        public string substation_code { get; set; }

        public string Name { get; set; }
        public string plant_number { get; set; }

        public int asset_eq_no { get; set; }

        public string eq_status { get; set; }

        public string serial_number { get; set; }

        public string modifier_code { get; set; }

        public int location_equipment_number { get; set; }

        public string component_code { get; set; }

        public DateTime warrantydate { get; set; }

        public int equipment_age { get; set; }// needs auto timer

        public string stock_code { get; set; }

        public string po_no { get; set; }

        public int rated_volts { get; set; }

        public int nominal_volts { get; set; }

        public string manufacture_name { get; set; }

        public string specifiaction_title { get; set; }

        public string specification_no { get; set; }

        public string specifiaction_item_no { get; set; }

        public string last_install_date { get; set; }

        public string equipment_class { get; set; }

        public string Equimpent_class_decription { get; set; }

        public bool complete { get; set; }
    }
}