using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace ACMEWebManager.Models
{
    public class DNSProvider : BasePoco
    {
        [Display(Name = "云服务商")]
        public ProviderType ProviderType { get; set; }

        [Display(Name = "AppId")]
        public string AppId { get; set; }
        [Display(Name = "SecretId")]
        public string SecretId { get; set; }
        [Display(Name = "SecretKey")]
        public string SecretKey { get; set; }
    }

    public enum ProviderType
    {
        [Display(Name = "阿里云")]
        Aliyun,
        [Display(Name = "腾讯云")]
        Tencent,
        [Display(Name = "华为云")]
        Huawei
    }
}
