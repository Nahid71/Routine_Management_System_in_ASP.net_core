using System;
using System.Collections.Generic;

namespace Routine_Manage.Models
{
    public partial class Registry
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
