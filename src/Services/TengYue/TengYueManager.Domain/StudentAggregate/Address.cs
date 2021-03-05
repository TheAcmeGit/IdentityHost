using Shared.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TengYueManager.Domain.StudentAggregate
{
    public class Address:ValueObject
    {
        public string City { get; set; }
        public string Street { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
        public Address()
        {

        }

        public Address(string city, string street)
        {
            City = city;
            Street = street;
        }
    }
}
