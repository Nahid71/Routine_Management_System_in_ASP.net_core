using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Routine_Manage.Models
{
    public partial class Student
    {
        public short Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Class { get; set; }

        public virtual Class ClassNavigation { get; set; }
    }
}
