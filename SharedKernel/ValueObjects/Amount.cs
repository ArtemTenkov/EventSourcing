﻿using System;

namespace SharedKernel.ValueObjects
{
    public class Amount
    {
        public double Value { get; private set; }

        private Amount(double value)
        {
            if (value < 0)
                throw new Exception($"Amount should be greater than zero ({value}).");

            Value = value;
        }

        public static Amount Create(double value)
        {
            return new Amount(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Amount operator +(Amount amount1, Amount amount2)
        {
            return new Amount(amount1.Value + amount2.Value);
        }

        public static Amount operator -(Amount amount1, Amount amount2)
        {
            return new Amount(amount1.Value - amount2.Value);
        }

        public static bool operator <(Amount amount1, Amount amount2)
        {
            return amount1.Value < amount2.Value;
        }

        public static bool operator >(Amount amount1, Amount amount2)
        {
            return amount1.Value > amount2.Value;
        }

        public static bool operator <=(Amount amount1, Amount amount2)
        {
            return amount1.Value <= amount2.Value;
        }

        public static bool operator >=(Amount amount1, Amount amount2)
        {
            return amount1.Value >= amount2.Value;
        }
    }
}
