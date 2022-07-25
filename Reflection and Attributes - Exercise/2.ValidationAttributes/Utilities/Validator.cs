namespace ValidationAttributes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ValidationAttributes.Models;

    public class Validator
    {
        public static bool IsValid(object obj)
        {

            var type = typeof(Person);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (MyValidationAttributes attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
