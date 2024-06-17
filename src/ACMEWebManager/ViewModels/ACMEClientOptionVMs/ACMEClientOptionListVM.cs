using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ACMEWebManager.Models;


namespace ACMEWebManager.ViewModels.ACMEClientOptionVMs
{
    public partial class ACMEClientOptionListVM : BasePagedListVM<ACMEClientOption_View, ACMEClientOptionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "", dialogWidth: 800),
                this.MakeStandardAction("ACMEClientOption", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], ""),
            };
        }


        protected override IEnumerable<IGridColumn<ACMEClientOption_View>> InitGridHeader()
        {
            return new List<GridColumn<ACMEClientOption_View>>{
                this.MakeGridHeader(x => x.Mail),
                this.MakeGridHeader(x => x.CA),
                this.MakeGridHeader(x => x.Domain),
                this.MakeGridHeader(x => x.CountryName),
                this.MakeGridHeader(x => x.State),
                this.MakeGridHeader(x => x.Locality),
                this.MakeGridHeader(x => x.Organization),
                this.MakeGridHeader(x => x.OrganizationUnit),
                this.MakeGridHeader(x => x.CommonName),
                this.MakeGridHeader(x => x.AppId_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ACMEClientOption_View> GetSearchQuery()
        {
            var query = DC.Set<ACMEClientOption>()
                .CheckEqual(Searcher.CA, x=>x.CA)
                .CheckContain(Searcher.Domain, x=>x.Domain)
                .Select(x => new ACMEClientOption_View
                {
				    ID = x.ID,
                    Mail = x.Mail,
                    CA = x.CA,
                    Domain = x.Domain,
                    CountryName = x.CountryName,
                    State = x.State,
                    Locality = x.Locality,
                    Organization = x.Organization,
                    OrganizationUnit = x.OrganizationUnit,
                    CommonName = x.CommonName,
                    AppId_view = x.DNSProvider.AppId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ACMEClientOption_View : ACMEClientOption{
        [Display(Name = "AppId")]
        public String AppId_view { get; set; }

    }
}
