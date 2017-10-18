using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Routine_Manage.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ClassRoutine = new HashSet<ClassRoutine>();
            ClaSub = new HashSet<ClaSub>();
            ExamRoutine = new HashSet<ExamRoutine>();
        }

        public short SCode { get; set; }
        [DisplayName("Subject Name")]
        public string SName { get; set; }
        [DisplayName("Subject Type")]
        public string SType { get; set; }
        [DisplayName("Teacher Id")]
        public short? TId { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<ClaSub> ClaSub { get; set; }
        public virtual ICollection<ExamRoutine> ExamRoutine { get; set; }
        public virtual Teacher T { get; set; }
    }
}
