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
    public partial class ACMEClientOptionBatchVM : BaseBatchVM<ACMEClientOption, ACMEClientOption_BatchEdit>
    {
        public ACMEClientOptionBatchVM()
        {
            ListVM = new ACMEClientOptionListVM();
            LinkedVM = new ACMEClientOption_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ACMEClientOption_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
