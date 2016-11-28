using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.DbFirstManual.Data.Core.Domains
{
    public class Employee
    {
        [Required]
        public int ID { get; set; }

        [MaxLength(10)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
