using Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TengYueManager.Domain.DomainEvent;

namespace TengYueManager.Domain.StudentAggregate
{
   public class Student:Entity<Guid>
    {
        public Student()
        {

        }

        public Student(string name, string age, string sex, Address address)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Address = address;
            AddDomainEvent(new CreateStudentOkSayHelloDomainEvent(name));
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public Address Address { get; set; }
    }
}
