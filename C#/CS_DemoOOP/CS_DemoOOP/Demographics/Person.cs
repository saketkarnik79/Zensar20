using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Person
    {
        //public int id;
        //public string name;
        //public DateTime dateOfBirth;

        private int id;
        private string name;
        private DateTime dateOfBirth;

        public int GetId()
        {
            // You can add auth logic here if needed
            return id;
        }

        //public string GetName()
        //{
        //    // You can add auth logic here if needed
        //    return name;
        //}

        //public DateTime GetDateOfBirth()
        //{
        //    // You can add auth logic here if needed
        //    return dateOfBirth;
        //}

        //public void SetId(int id)
        //{
        //    // You can add auth & validation logic here if needed
        //    this.id = id;
        //}

        //public void SetName(string name)
        //{
        //    // You can add auth & validation logic here if needed
        //    this.name = name;
        //}

        //public void SetDateOfBirth(DateTime dateOfBirth)
        //{
        //    // You can add auth & validation logic here if needed
        //    this.dateOfBirth = dateOfBirth;
        //}

        // Use properties instead of explicit getter/setter methods for better readability and maintainability
        public int Id 
        {
            get 
            {
                // You can add auth logic here if needed
                return id; 
            }
            set 
            {
                // You can add auth & validation logic here if needed
                if (value <= 0)
                {
                    throw new ArgumentException("ID must be a positive integer.");
                }
                id = value; 
            }
        }

        public string Name
        {
            get
            {
                // You can add auth logic here if needed
                return name;
            }
            set
            {
                // You can add auth & validation logic here if needed
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                // You can add auth logic here if needed
                return dateOfBirth;
            }
            set
            {
                // You can add auth & validation logic here if needed
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of Birth cannot be in the future.");
                }
                if (DateTime.Now.Year - value.Year < 18)
                {
                    throw new ArgumentException("Person must be at least 18 years old.");
                }
                dateOfBirth = value;
            }
        }

        public Person()
        {
            id = 0;
            name = string.Empty;
            dateOfBirth = DateTime.MinValue;
        }

        public Person(int id, string name, DateTime dateOfBirth)
        {
            //this.id = id;
            //this.name = name;
            //this.dateOfBirth = dateOfBirth;

            Id = id; // Using property to leverage validation
            Name = name; // Using property to leverage validation
            DateOfBirth = dateOfBirth; // Using property to leverage validation
        }

        public virtual string DisplayInfo()
        {
            // return $"ID: {id}, Name: {name}, Date of Birth: {dateOfBirth.ToShortDateString()}";
            return $"ID: {Id}, Name: {Name}, Date of Birth: {DateOfBirth.ToShortDateString()}";
        }
    }
}
