using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CsvPlayground.App.Core.Formatter
{
    public class CsvInputFormatter : TextInputFormatter
    {
        private readonly CsvConfiguration _config = new(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";"
        };
        public CsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override bool CanRead(InputFormatterContext context) =>
            context.ModelType.GetInterface("IEnumerable") != null;

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {

            var type = context.ModelType.GetGenericArguments()[0];

            using var reader = new StreamReader(context.HttpContext.Request.Body, encoding);

            using var csv = new CsvReader(reader, _config);
            var records = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));

            while (csv.Read())
                records.Add(csv.GetRecord(type));

            return InputFormatterResult.SuccessAsync(records);
        }


    }


}