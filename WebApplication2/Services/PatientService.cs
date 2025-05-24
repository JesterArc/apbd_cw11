using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;

namespace WebApplication2.Services;

public class PatientService : IPatientService
{
    private readonly DatabaseContext _context;
    public PatientService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<bool> DoesPatientExist(int id)
    {
        return (await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == id)) != null;
    }

    public async Task<PatientDto> GetPatientInformation(int id)
    {
        List<PrescriptionDto> prescriptionDtos = await _context.Prescriptions
            .Join(_context.Doctors, pr => pr.IdDoctor, d => d.IdDoctor, (pr, d) => new { pr, d })
            .Where(prd => prd.pr.IdPatient == id)
            .Select(prd => new PrescriptionDto()
            {
                IdPrescription = prd.pr.IdPrescription,
                Date = prd.pr.Date,
                DueDate = prd.pr.DueDate,
                Medicaments = new List<PrescriptionMedicamentDto>(),
                Doctor = new DoctorDto() {
                        IdDoctor = prd.d.IdDoctor,
                        FirstName = prd.d.FirstName,
                        LastName = prd.d.LastName
                    }
            }).ToListAsync();

        foreach (var prescription in prescriptionDtos)
        {
            var medicaments = await _context.Medicaments
                .Join(_context.PrescriptionMedicaments, m => m.IdMedicament, pm => pm.IdMedicament,
                    (m, pm) => new { m, pm })
                .Where(pm => pm.pm.IdPrescription == prescription.IdPrescription)
                .Select(pm => new PrescriptionMedicamentDto()
                {
                    IdMedicament = pm.pm.IdMedicament,
                    Name = pm.m.Name,
                    Dose = pm.pm.Dose,
                    Details = pm.pm.Details,
                }).ToListAsync();
            medicaments.AddRange(prescription.Medicaments);
            prescription.Medicaments = medicaments;
        }
        prescriptionDtos = prescriptionDtos.OrderBy(p => p.DueDate).ToList();
        return await _context.Patients.Select(p =>
            new PatientDto()
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Prescriptions = prescriptionDtos
            }).FirstAsync(p => p.IdPatient == id);
    }
}