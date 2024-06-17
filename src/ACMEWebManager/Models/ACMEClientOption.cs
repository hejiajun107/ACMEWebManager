using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace ACMEWebManager.Models
{
    public class ACMEClientOption : BasePoco
    {
        [Display(Name = "邮箱")]
        public string Mail { get; set; }
        [Display(Name = "CA")]
        public CA CA { get; set; } = CA.LetsEncrypt;
        [Display(Name = "域名")]
        public string Domain { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Locality")]
        public string Locality { get; set; }
        [Display(Name = "Organization")]
        public string Organization { get; set; }
        [Display(Name = "Organization Unit")]
        public string OrganizationUnit { get; set; }
        [Display(Name = "Common Name")]
        public string CommonName { get; set; }

        public DNSProvider DNSProvider { get; set; }
        [Display(Name = "云服务商")]
        public Guid? DNSProviderId { get; set; }

        [Display(Name = "验证方式")]
        public ValidateMethod ValidateMethod { get; set; }
        [Display(Name = "验证前执行")]
        public string ScriptBeforeValidate { get; set; }
        
    }

    public enum ValidateMethod
    {
        TXT,
        DNS
    }

    public enum CA
    {
        [Display(Name = "Let's Encrypt")]
        LetsEncrypt
    }
}
