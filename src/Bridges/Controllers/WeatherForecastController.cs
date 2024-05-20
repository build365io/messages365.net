using Bridges.Reversegeocoding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bridges.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
      
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<Address>> ReverseGeocode()
    {
        RootObject rootObject = GetAddress.ReverseGeocode(52.373056,4.892222);
        Console.WriteLine("Full Address "+rootObject.display_name);
        return Ok(rootObject);
    }
}
