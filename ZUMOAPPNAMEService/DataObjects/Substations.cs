using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService
{
    public class Substations : EntityData
    {
        public string Substation_Code { get; set; }
        public string Substation_Name { get; set; }
        public string Area { get; set; }

    }
}