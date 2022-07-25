namespace ValidationAttributes.Utilities
{
    using System;

    public abstract class MyValidationAttributes : Attribute
    {
        public abstract bool IsValid(object obj);
    }

}