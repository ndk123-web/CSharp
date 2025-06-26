// Controllers/HelloController.cs
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetHello()
    {
        return Ok("Hello from your API!");
    }

    // HttpPost is Method Level Attribute
    [HttpPost]
    // IActionResult gives return type of for controller like Ok(), BadRequest(), NotFound()
    public IActionResult PostData([FromBody] string name)
    {
        return Ok($"Received: {name}");
    }
}
