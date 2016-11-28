namespace Sample1.DbFirstManual2.Data.Core.Domains
{
    using System.ComponentModel.DataAnnotations;
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
