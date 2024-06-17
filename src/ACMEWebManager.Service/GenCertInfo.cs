using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEWebManager.Service
{
    public class GenCertInfo
    {
        public string Account { get; set; }

        public string Domain { get; set; }

        public string CountryName {get;set;}
        public string State { get; set; }
        public string Locality { get; set; }
        public string Organization { get; set; }
        public string OrganizationUnit { get; set; }
    }
}
