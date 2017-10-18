using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Routine_Manage.Models
{
    public partial class ClassRoutine
    {
        public short Serial { get; set; }
        [DisplayName("Class")]
        public string CStage { get; set; }
        [DisplayName("Subject Name")]
        public short SCode { get; set; }
        [DisplayName("Room No")]
        public short RoomNo { get; set; }
        public string Day { get; set; }
        public TimeSpan? Time { get; set; }
        [DisplayName("Class")]
        public virtual Class CStageNavigation { get; set; }
        [DisplayName("Room No")]
        public virtual Room RoomNoNavigation { get; set; }
        [DisplayName("Subject Code")]
        public virtual Subject SCodeNavigation { get; set; }
    }
}
