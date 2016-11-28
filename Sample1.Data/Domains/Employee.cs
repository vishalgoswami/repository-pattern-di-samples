using System.ComponentModel.DataAnnotations;

namespace Sample1.Data.Domains
{
    public class Employee
    {
        [Required]
        public int ID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
