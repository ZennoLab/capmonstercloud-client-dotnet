using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zennolab.CapMonsterCloud.Json
{
    internal sealed class DictionaryToSemicolonSplittedStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsAssignableFrom(typeof(IDictionary<string, string>));

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = string.Join(";", ((IDictionary<string, string>)value).Select(kvp => $"{kvp.Key}={kvp.Value}"));
            writer.WriteValue(result);
        }
    }
}
