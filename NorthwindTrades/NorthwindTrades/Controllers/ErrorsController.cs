using Microsoft.AspNetCore.Mvc;

namespace NorthwindTrades.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}