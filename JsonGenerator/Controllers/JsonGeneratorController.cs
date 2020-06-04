using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace JsonGenerator.Controllers
{
    [Route("generate")]
    [ApiController]
    public class JsonGeneratorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Instruct()
        {
            return Ok("Use Postman to post json template to /generate.");
        }
        [HttpPost]
        public ActionResult<JObject> Post([FromBody]dynamic template)
        {
            JObject generatedJsonResult = Parse(template);

            return Ok(generatedJsonResult);
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
                    jtoken = Random();
                //do stuff
            }
            return jtoken;
        }

        private int Random()
        {
            return new Random().Next();
        }
    }
}