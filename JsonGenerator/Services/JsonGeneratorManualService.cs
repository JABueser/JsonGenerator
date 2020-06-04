using JsonGenerator.Contracts;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace JsonGenerator.Services
{
    //deprecated
    public class JsonGeneratorManualService
    {
        private readonly IOperationsService _operations;

        public JsonGeneratorManualService(IOperationsService operations)
        {
            _operations = operations;
        }
        public JObject GenerateJson(dynamic source)
        {
            JObject generatedJsonResult = Parse(source);
            return generatedJsonResult;
        }

        private JObject Parse(dynamic json)
        {
            foreach (JProperty item in json)
            {
                if (!item.Value.HasValues)
                    item.Value = Evaluate(item.Value);
                else
                    Parse(item.Value);
            }
            return json;
        }
        private JToken Evaluate(JToken jtoken)
        {
            string tag = jtoken.ToString();
            Regex tagPattern = new Regex(@"{{?(#[a-z])?[a-z].+[a-z]\(\)}}");
            if (tagPattern.IsMatch(tag))
            {
                if (tag.Equals("{{random()}}"))
                    jtoken = _operations.GetRandomInt();
                //do stuff
            }
            return jtoken;
        }
    }
}
