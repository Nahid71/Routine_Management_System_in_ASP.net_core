using System;
using System.Collections.Generic;

namespace Routine_Manage.Models
{
    public partial class Room
    {
        public Room()
        {
            ClassRoutine = new HashSet<ClassRoutine>();
            ExamRoutine = new HashSet<ExamRoutine>();
        }

        public short RoomNo { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<ExamRoutine> ExamRoutine { get; set; }
    }
}
