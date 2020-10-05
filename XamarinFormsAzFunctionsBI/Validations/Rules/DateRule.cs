using System;
namespace XamarinFormsAzFunctionsBI.Validations.Rules
{
    public class DateRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            DateTime dateTime;
            return DateTime.TryParse(str, out dateTime);
        }
    }
}
