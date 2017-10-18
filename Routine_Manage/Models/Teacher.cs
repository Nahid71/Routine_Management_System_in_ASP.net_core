using System;
using System.Collections.Generic;

namespace Routine_Manage.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Subject = new HashSet<Subject>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
    }
}
