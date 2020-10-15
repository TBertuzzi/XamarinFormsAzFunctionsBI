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

            var dataMinima = new DateTime(1940, 01, 01);
            if (DateTime.TryParse(str, out dateTime))
            {
                if (dateTime < dataMinima)
                    return false;
            }
            else
                return false;

            return true;
        }
    }
}
