using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using ACMEWebManager.Models;


namespace ACMEWebManager.ViewModels.ACMEClientOptionVMs
{
    public partial class ACMEClientOptionVM : BaseCRUDVM<ACMEClientOption>
    {
        public List<ComboSelectListItem> AllDNSProviders { get; set; }

        public ACMEClientOptionVM()
        {
            SetInclude(x => x.DNSProvider);
        }

        protected override void InitVM()
        {
            AllDNSProviders = DC.Set<DNSProvider>().GetSelectListItems(Wtm, y => y.AppId);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
