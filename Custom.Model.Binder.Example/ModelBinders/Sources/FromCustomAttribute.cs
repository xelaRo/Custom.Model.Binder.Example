using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Custom.Model.Binder.Example.ModelBinders
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromCustomAttribute : Attribute, IFromQueryMetadata, IBindingSourceMetadata
    {
        public BindingSource? BindingSource => new BindingSource(
              "Custom",
              "Custom",
              true,
              false
        );

        public string Name { get; set; }
    }
}
