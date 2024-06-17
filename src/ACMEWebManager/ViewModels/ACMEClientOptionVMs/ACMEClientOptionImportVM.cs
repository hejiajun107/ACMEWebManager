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
    public partial class ACMEClientOptionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "邮箱")]
        public ExcelPropety Mail_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.Mail);
        [Display(Name = "CA")]
        public ExcelPropety CA_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.CA);
        [Display(Name = "域名")]
        public ExcelPropety Domain_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.Domain);
        [Display(Name = "Country Name")]
        public ExcelPropety CountryName_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.CountryName);
        [Display(Name = "State")]
        public ExcelPropety State_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.State);
        [Display(Name = "Locality")]
        public ExcelPropety Locality_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.Locality);
        [Display(Name = "Organization")]
        public ExcelPropety Organization_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.Organization);
        [Display(Name = "Organization Unit")]
        public ExcelPropety OrganizationUnit_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.OrganizationUnit);
        [Display(Name = "Common Name")]
        public ExcelPropety CommonName_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.CommonName);
        public ExcelPropety DNSProvider_Excel = ExcelPropety.CreateProperty<ACMEClientOption>(x => x.DNSProviderId);

	    protected override void InitVM()
        {
            DNSProvider_Excel.DataType = ColumnDataType.ComboBox;
            DNSProvider_Excel.ListItems = DC.Set<DNSProvider>().GetSelectListItems(Wtm, y => y.AppId);
        }

    }

    public class ACMEClientOptionImportVM : BaseImportVM<ACMEClientOptionTemplateVM, ACMEClientOption>
    {

    }

}
