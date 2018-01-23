using System;
using System.Text.RegularExpressions;

namespace SharedKernel.ValueObjects
{
    public class Name
    {
        public string Value { get; }
        private Name(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Empty name value");

            if (!new Regex(@"^[a-zA-Z0-9 ]*$").IsMatch(value))
                throw new ArgumentOutOfRangeException("Only letters and numbers are allowed");

            Value = value;
        }

        public static Name Create(string value)
        {
            return new Name(value);
        }
    }
}
