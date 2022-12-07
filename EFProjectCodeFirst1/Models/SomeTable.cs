using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1.Models
{
    internal class SomeTable
    {
        [Key]
        public int MyProperty { get; set; }
        public DateTime? MyDate { get; set; }
        public bool? MyBoolProperty { get; set; }
        public string MyStringProperty { get; set; }
    }
}
