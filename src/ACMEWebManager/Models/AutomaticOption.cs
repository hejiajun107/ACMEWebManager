using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace ACMEWebManager.Models
{
    public class AutomaticOption : BasePoco
    {
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "证书路径")]
        public string Dest { get; set; }
        [Display(Name = "替换证书后执行")]
        public string ScriptAfter { get; set; }
        [Display(Name = "证书类型")]
        public CertType CertType { get; set; }
        [Display(Name = "运行环境")]
        public RunAt RunAt { get; set; }

        
    }

    public enum CertType
    {
        [Display(Name = "pem")]
        pem,
        [Display(Name = "pfx")]
        pfx
    }

    public enum RunAt
    {
        [Display(Name = "服务器")]
        Server,
        [Display(Name = "客户端")]
        Client
    }
}
