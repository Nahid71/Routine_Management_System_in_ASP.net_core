using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Routine_Manage.Models
{
    public partial class ExamRoutine
    {
        public short Serial { get; set; }
        [DisplayName("Subject Code")]
        public short SCode { get; set; }
        
        [DisplayName("Class")]
        public string CStage { get; set; }
        [DisplayName("Room No")]
        public short RoomNo { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        [DisplayName("Class")]
        public virtual Class CStageNavigation { get; set; }
        [DisplayName("Room No")]
        public virtual Room RoomNoNavigation { get; set; }
        [DisplayName("Subject Code")]
        public virtual Subject SCodeNavigation { get; set; }
    }
}
