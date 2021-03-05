using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TengYueManager.Domain.StudentAggregate;

namespace TengYueManager.Api.Application.Commands
{
    public class CreateStudentCommand:IRequest<bool>
    {
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Sex { get; private set; }
        public Address Address { get; private set; }

        public CreateStudentCommand(string name, string age, string sex, Address address)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Address = address;
        }
    }
}
