// Controllers/HelloController.cs
using Microsoft.AspNetCore.Mvc;

// This classes are like pydantic of python that automatically extracts the data from body or query
public class NameRequest{
    public string Name {get; set;}
}

// This classes are like pydantic of python that automatically extracts the data from body or query
public class NameQuery{
    public string? Q { get; set; }
    public string? Target {get; set;}
}

// ApiController is class level Attribute
// ApiController gives [FromBody] and [FromQuery] like attributes 
[ApiController]
// Route is class level Attribute
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    // HttpGet is Method Level Attribute
    [HttpGet]
    // IActionResult gives return type of for controller like Ok(), BadRequest(), NotFound()
    public IActionResult GetHello([FromQuery] NameQuery query)
    {
        if (query.Q == null){
        return Ok("Hello from your API!");
        }

        if (query.Target == null){
        return Ok("Hello from your API!");
        }

        return Ok($"Hello from your API and Query for q: {query.Q} and target: {query.Target}");
    }

    // HttpPost is Method Level Attribute
    [HttpPost]
    // IActionResult gives return type of for controller like Ok(), BadRequest(), NotFound()
    public IActionResult PostData([FromBody] NameRequest request)
    {
        return Ok($"Received: {request.Name}");
    }
}
