using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zennolab.CapMonsterCloud.Json
{
    internal sealed class DictionaryToSemicolonSplittedStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsAssignableFrom(typeof(IDictionary<string, string>));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();
            var regexValidation = new Regex("^((.*)(=?){2};?)+$");

            if (regexValidation.IsMatch(value))
                try
                {
                    return value.Split(';').Select(item =>
                    {
                        var keyValueItem = item.Split('=');
                        return new KeyValuePair<string, string>(keyValueItem[0], keyValueItem[1]);
                    }).ToDictionary(x => x.Key, x => x.Value);
                }
                catch (Exception) { }

            throw new JsonReaderException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = string.Join(";", ((IDictionary<string, string>)value).Select(kvp => $"{kvp.Key}={kvp.Value}"));
            writer.WriteValue(result);
        }
    }
}
