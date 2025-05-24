using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.DTOs;

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

    [HttpPut]
    public async Task<IActionResult> AddNewPrescriptionAsync([FromBody] CreatePrescriptionDto createPrescription)
    {
        // Does Doctor Exist
        if (!await _patientService.DoesDoctorExist(createPrescription.IdDoctor))
        {
            return NotFound($"Doctor with id = {createPrescription.IdDoctor} does not exist");
        }
        // Is date correct
        if (createPrescription.DueDate < createPrescription.Date)
        {
            return BadRequest("Due date cannot be earlier than date");
        }
        // Is there more than 10 medicine
        if (createPrescription.Medicaments.Count > 10)
        {
            return BadRequest("Single Prescription cannot have more than 10 Medicaments");
        }
        // // Does each Medicine Exist
        foreach (var medicament in createPrescription.Medicaments)
            if (!await _patientService.DoesMedicamentExist(medicament.IdMedicament))
            {
                return NotFound($"Could not find such medicament in database: {medicament.IdMedicament}");
            }
        // Does Patient Exist
        if (!await _patientService.DoesPatientExist(createPrescription.Patient.FirstName, 
                createPrescription.Patient.LastName, createPrescription.Patient.BirthDate))
        {
            await _patientService.AddPatient(createPrescription.Patient.FirstName,
                createPrescription.Patient.LastName, createPrescription.Patient.BirthDate);
        }
        createPrescription.Patient.IdPatient = await _patientService.GetPatientId(createPrescription.Patient.FirstName,
            createPrescription.Patient.LastName, createPrescription.Patient.BirthDate);
        try
        {
            await _patientService.AddPrescription(createPrescription);
            return Ok(createPrescription);
        }
        catch (Exception e)
        {
            return BadRequest("Transaction failed");
        }
    }
}