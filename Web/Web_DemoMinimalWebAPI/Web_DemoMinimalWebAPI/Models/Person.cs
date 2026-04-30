namespace Web_DemoMinimalWebAPI.Models
{
    public class Person
    {
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
