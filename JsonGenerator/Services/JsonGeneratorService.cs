using HandlebarsDotNet;
using JsonGenerator.Contracts;
using Newtonsoft.Json.Linq;

namespace JsonGenerator.Services
{
    public class JsonGeneratorService : IJsonGeneratorService
    {
        private readonly IOperationsService _operations;
        private readonly IHandlebarsSetup _setup;

        public JsonGeneratorService(IOperationsService operations, IHandlebarsSetup setup)
        {
            _operations = operations;
            _setup = setup;
        }
        public JObject GenerateJson(dynamic source)
        {

            _setup.load();
            var template = Handlebars.Compile(source.ToString());

            var data = new
            {
                random = _operations.GetRandomInt(),
                guid = _operations.GetGuid()
            };
            var result = template(data);
            return JObject.Parse(result);
        }
    }
}
