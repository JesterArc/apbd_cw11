using WebApplication2.Models;
using WebApplication2.DTOs;
namespace WebApplication2.Services;

public interface IPatientService
{
    public Task<bool> DoesPatientExist(int id);
    public Task<PatientDto> GetPatientInformation(int id);
}