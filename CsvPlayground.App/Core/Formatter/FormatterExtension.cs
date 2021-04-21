using Microsoft.Extensions.DependencyInjection;

namespace CsvPlayground.App.Core.Formatter
{
    public static class FormatterExtension
    {
        public static IMvcBuilder AddCsvFormatter(this IMvcBuilder mvcBuilder) =>
         mvcBuilder.AddMvcOptions(options =>
            {

                options.InputFormatters.Add(new CsvInputFormatter());
                options.OutputFormatters.Add(new CsvOutputFormatter());
            });

    }
}