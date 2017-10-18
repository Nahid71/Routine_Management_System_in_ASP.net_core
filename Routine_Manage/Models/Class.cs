using System;
using System.Collections.Generic;

namespace Routine_Manage.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassRoutine = new HashSet<ClassRoutine>();
            ClaSub = new HashSet<ClaSub>();
            ExamRoutine = new HashSet<ExamRoutine>();
            Student = new HashSet<Student>();
        }

        public string CStage { get; set; }
        public string CType { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutine { get; set; }
        public virtual ICollection<ClaSub> ClaSub { get; set; }
        public virtual ICollection<ExamRoutine> ExamRoutine { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
