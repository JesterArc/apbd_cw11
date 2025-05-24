using WebApplication2.Models;
using WebApplication2.DTOs;
namespace WebApplication2.Services;

public interface IPatientService
{
    public Task<bool> DoesPatientExist(int id);
    public Task<bool> DoesPatientExist(string firstName, string lastName, DateOnly birthDate);
    public Task<PatientWithPrescriptionsDto> GetPatientInformation(int id);
    public Task<int> GetPatientId(string firstName, string lastName, DateOnly birthDate);
    public Task AddPatient(string firstName, string lastName, DateOnly birthDate);
    public Task<bool> DoesMedicamentExist(int id);
    public Task AddPrescription(CreatePrescriptionDto prescription);
    public Task<bool> DoesDoctorExist(int id);
}