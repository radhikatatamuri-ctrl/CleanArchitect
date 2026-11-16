using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.ValueObjects
{

    public class BlogName
    {
        public string Value { get; }

        private BlogName() { }
        public BlogName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Blog name cannot be empty");

            if (value.Length > 100)
                throw new ArgumentException("Blog name cannot exceed 100 characters");

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
