using System;
using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    public class RangeLengthAttribute : ValidationAttribute
    {
        public int Min { get; }
        public int Max { get; }

        public RangeLengthAttribute(int min, int max)
        {
            Max = Math.Max(max, min);
            Min = Math.Min(max, min);
        }

        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return false;
            }

            var length = stringValue.Length;
            return length >= Min && length <= Max;
        }
    }
}