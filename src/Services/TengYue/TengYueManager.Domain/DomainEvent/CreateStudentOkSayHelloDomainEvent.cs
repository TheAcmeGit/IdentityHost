using Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace TengYueManager.Domain.DomainEvent
{
    public class CreateStudentOkSayHelloDomainEvent : IDomainEvent
    {
        public string Name { get; private set; }

        public CreateStudentOkSayHelloDomainEvent(string name)
        {
            Name = name;
        }
    }
}
