using Custom.Model.Binder.Example.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Custom.Model.Binder.Example.ModelBinders.Providers
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(WeatherType))
            {
                return new BinderTypeModelBinder(typeof(CustomModelBinder));
            }

            return null;
        }
    }
}
