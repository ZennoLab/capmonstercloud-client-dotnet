using Newtonsoft.Json;
using System;

namespace Zennolab.CapMonsterCloud.Json
{
    internal sealed class NumericFlagConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(bool);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool)value ? 1 : 0);
        }
    }
}
