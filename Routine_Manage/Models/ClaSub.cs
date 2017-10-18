using System;
using System.Collections.Generic;

namespace Routine_Manage.Models
{
    public partial class ClaSub
    {
        public short Id { get; set; }
        public string CStage { get; set; }
        public short? SCode { get; set; }

        public virtual Class CStageNavigation { get; set; }
        public virtual Subject SCodeNavigation { get; set; }
    }
}
