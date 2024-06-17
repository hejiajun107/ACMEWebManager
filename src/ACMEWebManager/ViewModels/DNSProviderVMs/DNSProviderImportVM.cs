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
    public partial class DNSProviderTemplateVM : BaseTemplateVM
    {
        [Display(Name = "云服务商")]
        public ExcelPropety ProviderType_Excel = ExcelPropety.CreateProperty<DNSProvider>(x => x.ProviderType);
        [Display(Name = "AppId")]
        public ExcelPropety AppId_Excel = ExcelPropety.CreateProperty<DNSProvider>(x => x.AppId);
        [Display(Name = "SecretId")]
        public ExcelPropety SecretId_Excel = ExcelPropety.CreateProperty<DNSProvider>(x => x.SecretId);
        [Display(Name = "SecretKey")]
        public ExcelPropety SecretKey_Excel = ExcelPropety.CreateProperty<DNSProvider>(x => x.SecretKey);

	    protected override void InitVM()
        {
        }

    }

    public class DNSProviderImportVM : BaseImportVM<DNSProviderTemplateVM, DNSProvider>
    {

    }

}
