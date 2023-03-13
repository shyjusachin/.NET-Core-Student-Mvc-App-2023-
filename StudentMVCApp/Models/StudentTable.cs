using System;
using System.Collections.Generic;

#nullable disable

namespace StudentMVCApp.Models
{
    public partial class StudentTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
