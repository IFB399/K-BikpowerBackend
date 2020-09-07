using Microsoft.Azure.Mobile.Server;
using System;

namespace ZUMOAPPNAMEService
{
    public class Substation : EntityData
    {
        public string Substation_Code { get; set; } //should be Substation_code
        public string Substation_Name { get; set; }
        public string Area { get; set; }

    }
}