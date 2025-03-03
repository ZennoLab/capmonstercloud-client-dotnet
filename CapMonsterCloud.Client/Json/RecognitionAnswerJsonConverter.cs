using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Json
{
    internal class RecognitionAnswerJsonConverter : JsonConverter<DynamicComplexImageTaskResponse>
    {
        public override DynamicComplexImageTaskResponse ReadJson(JsonReader reader, Type objectType, DynamicComplexImageTaskResponse existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            if (!obj.ContainsKey("metadata") || !obj.ContainsKey("answer"))
                throw new JsonSerializationException("Missing 'metadata' or 'answer' field in response");

            string answerType = obj["metadata"]?["AnswerType"]?.ToString();
            if (string.IsNullOrEmpty(answerType))
                throw new JsonSerializationException("AnswerType is missing in metadata");

            JToken answerToken = obj["answer"];
            DynamicComplexImageTaskResponse response = new DynamicComplexImageTaskResponse
            {
                Metadata = new DynamicComplexImageTaskResponse.RecognitionMetadata
                {
                    AnswerType = answerType
                }
            };

            switch (answerType)
            {
                case "NumericArray":
                    response.Answer = new RecognitionAnswer
                    {
                        NumericAnswer = answerToken.ToObject<decimal[]>()
                    };
                    break;
                case "Grid":
                    response.Answer = new RecognitionAnswer
                    {
                        GridAnswer = answerToken.ToObject<bool[]>()
                    };
                    break;
                default:
                    throw new JsonSerializationException($"Unknown AnswerType: {answerType}");
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, DynamicComplexImageTaskResponse value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();

            writer.WritePropertyName("answer");

            if (value.Metadata?.AnswerType == "Grid" && value.Answer?.GridAnswer != null)
            {
                serializer.Serialize(writer, value.Answer.GridAnswer);
            }
            else if (value.Metadata?.AnswerType == "NumericArray" && value.Answer?.NumericAnswer != null)
            {
                serializer.Serialize(writer, value.Answer.NumericAnswer);
            }
            else
            {
                throw new JsonSerializationException("Invalid or missing answer data for the specified AnswerType.");
            }

            writer.WritePropertyName("metadata");
            serializer.Serialize(writer, value.Metadata);

            writer.WriteEndObject();
        }
    }
}