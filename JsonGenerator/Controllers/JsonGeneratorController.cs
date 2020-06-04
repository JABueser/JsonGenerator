using JsonGenerator.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;


namespace JsonGenerator.Controllers
{
    [Route("generate")]
    [ApiController]
    public class JsonGeneratorController : ControllerBase
    {
        private readonly IJsonGeneratorService _service;

        public JsonGeneratorController(IJsonGeneratorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<string> Instruct()
        {
            return Ok("Use Postman to post json template to /generate.");
        }

        [HttpPost]
        public ActionResult<JObject> Post([FromBody]dynamic source)
        {
            try
            {
                return Ok(_service.GenerateJson(source));
            }catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            };
            
        }
    }
}