# JsonGenerator
A Web API that generates JSON from the given template. AUT-1056

Recommended usage:
Run locally on ports 
https://localhost:5001
http://localhost:5000

use Postman to POST to
https://localhost:5001/generate

set body -> raw -> JSON

Then paste the JSON found in Data/input.json

Supports Handlebars syntax.

Currently, the project is structured as such:
JsonGeneratorController calls the JsonGeneratorService. The GenerateJson calls HandlebarsSetup.cs to load all the custom Handlebar helpers. Then OperationsService creates and passes the data object to the template. Then the result is parsed and returned.

There are 2 places where data is being generated: the HandlebarsSetup.cs and the OperationsService.cs
The HandlebarsSetup.cs is being used to handle tags that have input. 
The OperationsService.cs handle tags that have just simple tags. 
