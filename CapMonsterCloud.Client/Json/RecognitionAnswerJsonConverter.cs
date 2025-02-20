using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Json
{
    internal class RecognitionAnswerJsonConverter : JsonConverter<RecognitionAnswer>
    {
        public override RecognitionAnswer ReadJson(JsonReader reader, Type objectType, RecognitionAnswer existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type != JTokenType.Array)
                throw new JsonSerializationException("Expected an array for answer field");

            if (!token.HasValues)
                throw new JsonSerializationException("Empty answer array");

            RecognitionAnswer answer = new RecognitionAnswer();

            if (token.First.Type == JTokenType.Boolean)
            {
                answer.GridAnswer = token.ToObject<bool[]>();
            }
            else if (token.First.Type == JTokenType.Integer || token.First.Type == JTokenType.Float)
            {
                answer.NumericAnswer = token.ToObject<decimal[]>();
            }
            else
            {
                throw new JsonSerializationException("Unexpected answer format");
            }

            return answer;
        }

        public override void WriteJson(JsonWriter writer, RecognitionAnswer value, JsonSerializer serializer)
        {
            if (value.IsGrid)
            {
                JToken.FromObject(value.GridAnswer).WriteTo(writer);
            }
            else if (value.IsNumeric)
            {
                JToken.FromObject(value.NumericAnswer).WriteTo(writer);
            }
            else
            {
                throw new JsonSerializationException("Invalid RecognitionAnswer state");
            }
        }
    }
}