using FlagExplorerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlagExplorerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesService _countriesService;

    public CountriesController(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _countriesService.GetCountries());
    }


    [HttpGet("{name}")]
    public async Task<IActionResult> Get(string name)
    {
        return Ok(await _countriesService.GetCountryDetails(name));
    }
}
