using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DemoEFCoreCodeFirst.Models
{
    [Table("Products")]
    internal class Product
    {
        [Column("Id")]
        [Key]
        public int ProductId { get; set; }

        [Required]
        //[StringLength(50, MinimumLength = 2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
