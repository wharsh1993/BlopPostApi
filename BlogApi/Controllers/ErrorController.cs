using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/error")]
public class ErrorController : ControllerBase
{
    [Route("/error")]
     [HttpGet]
    public IActionResult HandleError() => Problem();
}
