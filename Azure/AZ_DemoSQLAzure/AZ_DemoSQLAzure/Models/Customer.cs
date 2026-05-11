using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AZ_DemoSQLAzure.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] 
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
