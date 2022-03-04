using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class DateInFutureAttribute: ValidationAttribute
    {
        private readonly Func<DateTime> _dateTimeNowProvider;
        public DateInFutureAttribute(): this(() => DateTime.Now) { }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "A data deve ser futura";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _dateTimeNowProvider();
            }
            return isValid;
        }
    }
}
