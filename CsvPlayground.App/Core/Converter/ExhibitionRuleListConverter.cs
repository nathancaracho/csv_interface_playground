using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvPlayground.App.Dto;

namespace CsvPlayground.App.Core.Converter
{
    public class ExhibitionRuleListConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
            text
                ?.Split(',')
                ?.Where(rule => !string.IsNullOrWhiteSpace(rule))
                ?.Select(rule =>
                {
                    var splitted = rule.Split(':');
                    if (splitted.Length < 2)
                        throw new InvalidCastException($"Rule not in correct format - {rule}");

                    return new ExhibitionRule
                    {
                        Code = splitted[0],
                        Value = splitted[1]
                    };
                })
                ?.ToList()
            ?? Enumerable.Empty<ExhibitionRule>();

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) =>
            value is null
                ? string.Empty
                : string.Join(',', (value as IEnumerable<ExhibitionRule>)
                        .Select(rule => $"{rule.Code}:{rule.Value}"));

    }
}