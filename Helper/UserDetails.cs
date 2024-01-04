using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Helper
{
    public class UserDetails: System.Web.Services.Protocols.SoapHeader
    {
        public string userName { get; set; }
        public string password { get; set; }

        public bool IsValid()
        {
            string user = System.Configuration.ConfigurationManager.AppSettings["user"];
            string pass = System.Configuration.ConfigurationManager.AppSettings["pass"]; ;

            return this.userName == user && this.password == pass;
        }


    }
}