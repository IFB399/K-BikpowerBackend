using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService
{
    public class DecommissionData : EntityData
    {
        public string Date { get; set; }

        public string Details { get; set; }

        public string RegionName { get; set; }

        public string Location { get; set; }

        public string MovedTo { get; set; }

        public int WorkOrderNumber { get; set; }
    }
}