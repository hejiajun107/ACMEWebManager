using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ACMEWebManager.Models;


namespace ACMEWebManager.ViewModels.ACMEClientOptionVMs
{
    public partial class ACMEClientOptionSearcher : BaseSearcher
    {
        [Display(Name = "CA")]
        public CA? CA { get; set; }
        [Display(Name = "域名")]
        public String Domain { get; set; }

        protected override void InitVM()
        {
        }

    }
}
