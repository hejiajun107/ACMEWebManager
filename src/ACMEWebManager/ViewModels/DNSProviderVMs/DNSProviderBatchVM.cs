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
    public partial class DNSProviderBatchVM : BaseBatchVM<DNSProvider, DNSProvider_BatchEdit>
    {
        public DNSProviderBatchVM()
        {
            ListVM = new DNSProviderListVM();
            LinkedVM = new DNSProvider_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class DNSProvider_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
