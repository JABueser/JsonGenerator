using Newtonsoft.Json.Linq;

namespace JsonGenerator.Contracts
{
    public interface IJsonGeneratorService
    {
        JObject GenerateJson(dynamic source);
    }
}
