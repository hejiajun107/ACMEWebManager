using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ACMEWebManager.Models;


namespace ACMEWebManager.ViewModels.DNSProviderVMs
{
    public partial class DNSProviderListVM : BasePagedListVM<DNSProvider_View, DNSProviderSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "", dialogWidth: 800),
                this.MakeStandardAction("DNSProvider", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], ""),
            };
        }


        protected override IEnumerable<IGridColumn<DNSProvider_View>> InitGridHeader()
        {
            return new List<GridColumn<DNSProvider_View>>{
                this.MakeGridHeader(x => x.ProviderType),
                this.MakeGridHeader(x => x.AppId),
                this.MakeGridHeader(x => x.SecretId),
                this.MakeGridHeader(x => x.SecretKey),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<DNSProvider_View> GetSearchQuery()
        {
            var query = DC.Set<DNSProvider>()
                .CheckEqual(Searcher.ProviderType, x=>x.ProviderType)
                .Select(x => new DNSProvider_View
                {
				    ID = x.ID,
                    ProviderType = x.ProviderType,
                    AppId = x.AppId,
                    SecretId = x.SecretId,
                    SecretKey = x.SecretKey,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class DNSProvider_View : DNSProvider{

    }
}
