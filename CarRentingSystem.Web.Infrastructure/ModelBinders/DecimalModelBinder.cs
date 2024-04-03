namespace CarRentingSystem.Web.Infrastructure.ModelBinders
{
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None && !string.IsNullOrWhiteSpace(result.FirstValue))
            {
                decimal parsedValue = 0m;
                bool isSucceeded = false;

                try
                {
                    string decimalValue = result.FirstValue;

                    decimalValue = decimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decimalValue = decimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDecimal(decimalValue);
                    isSucceeded = true;
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
                }

                if(isSucceeded)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
