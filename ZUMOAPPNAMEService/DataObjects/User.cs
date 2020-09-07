using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class User : EntityData
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Permission { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}