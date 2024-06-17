using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ACMEWebManager.Models;


namespace ACMEWebManager.ViewModels.DNSProviderVMs
{
    public partial class DNSProviderSearcher : BaseSearcher
    {
        [Display(Name = "云服务商")]
        public ProviderType? ProviderType { get; set; }

        protected override void InitVM()
        {
        }

    }
}
