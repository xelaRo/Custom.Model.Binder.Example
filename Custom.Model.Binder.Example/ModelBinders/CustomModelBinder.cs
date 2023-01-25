using Custom.Model.Binder.Example.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Custom.Model.Binder.Example.ModelBinders
{
    public class CustomModelBinder : IModelBinder
    {
        private readonly IWeatherDataProvider weatherData;

        public CustomModelBinder(IWeatherDataProvider weatherData)
        {
            this.weatherData = weatherData;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            ValueProviderResult value = bindingContext.ValueProvider.GetValue("weatherType");

            if (value == ValueProviderResult.None)
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, "Weather Type is empty");
                return Task.CompletedTask;
            }

            var weatherType = weatherData.GetWeatherType(value.FirstValue);

            if (weatherType is null)
            {
                bindingContext.ModelState.TryAddModelError(value.FirstValue, "This type was weather was not found");
                return Task.CompletedTask;
            }


            bindingContext.Result = ModelBindingResult.Success(weatherType);
            return Task.CompletedTask;
        }
    }
}
