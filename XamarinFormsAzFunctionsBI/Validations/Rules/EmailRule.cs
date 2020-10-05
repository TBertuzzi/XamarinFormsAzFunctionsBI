using System;
using Xamarin.Forms.BehaviorValidationPack;

namespace XamarinFormsAzFunctionsBI.Validations.Rules
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return Validators.EmailValidator(str);
        }
    }
}
