using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientInformationAsync(int id)
    {
        if (!await _patientService.DoesPatientExist(id))
            return NotFound($"No patient with id = {id} exists");
        var info = await _patientService.GetPatientInformation(id);
        return Ok(info);
    }
    
}