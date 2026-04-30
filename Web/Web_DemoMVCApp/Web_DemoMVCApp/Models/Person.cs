using System.ComponentModel.DataAnnotations;

namespace Web_DemoMVCApp.Models
{
    public class Person
    {
        [Display(Name = "Person ID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
        }
    }
}
