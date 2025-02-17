using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Json
{
    internal class RecognitionAnswerJsonConverter : JsonConverter<RecognitionAnswer>
    {
        public override RecognitionAnswer ReadJson(JsonReader reader, Type objectType, RecognitionAnswer existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            JArray array;
            if (token.Type == JTokenType.Array)
            {
                array = (JArray)token;
            }
            else if (token.Type == JTokenType.Object)
            {
                JObject obj = (JObject)token;
                JToken innerToken = obj["DecimalValues"];

                if (innerToken == null)
                    innerToken = obj["BoolValues"];

                if (innerToken == null)
                    throw new JsonSerializationException("Expected an array in the object, but could not find an 'answer' (or 'data') property.");

                if (innerToken.Type != JTokenType.Array)
                    throw new JsonSerializationException("Expected the 'answer' (or 'data') property to be an array.");

                array = (JArray)innerToken;
            }
            else
            {
                throw new JsonSerializationException("Unexpected token type. Expected an array or an object containing an array.");
            }

            return ProcessArray(array);
        }

        private RecognitionAnswer ProcessArray(JArray array)
        {
            if (array.Count == 0)
                return new RecognitionAnswer { DecimalValues = new decimal[0] };

            bool isBoolArray = array[0].Type == JTokenType.Boolean;

            var boolList = new List<bool>();
            var decimalList = new List<decimal>();

            foreach (var item in array)
            {
                if (isBoolArray)
                {
                    if (item.Type != JTokenType.Boolean)
                        throw new JsonSerializationException("Inconsistent array types: Expected all booleans.");
                    boolList.Add(item.Value<bool>());
                }
                else
                {
                    if (item.Type != JTokenType.Float && item.Type != JTokenType.Integer)
                        throw new JsonSerializationException("Inconsistent array types: Expected all numbers.");
                    decimalList.Add(item.Value<decimal>());
                }
            }

            return isBoolArray
                ? new RecognitionAnswer { BoolValues = boolList.ToArray() }
                : new RecognitionAnswer { DecimalValues = decimalList.ToArray() };
        }

        public override void WriteJson(JsonWriter writer, RecognitionAnswer value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            if (value.IsBool)
            {
                foreach (var item in value.BoolValues)
                {
                    writer.WriteValue(item);
                }
            }
            else if (value.IsDecimal)
            {
                foreach (var item in value.DecimalValues)
                {
                    writer.WriteValue(item);
                }
            }

            writer.WriteEndArray();
        }
    }
}