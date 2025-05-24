using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Models;

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
    
    public async Task<bool> DoesPatientExist(string firstName, string lastName, DateOnly birthDate)
    {
        return (await _context.Patients.FirstOrDefaultAsync(p => 
            p.FirstName == firstName && p.LastName == lastName && p.BirthDate == birthDate)) != null;
    }
    
    public async Task<PatientWithPrescriptionsDto> GetPatientInformation(int id)
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
            new PatientWithPrescriptionsDto()
            {
                Patient = new PatientDto(){
                    IdPatient = p.IdPatient,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate
                },
                Prescriptions = prescriptionDtos
            }).FirstAsync(p => p.Patient.IdPatient == id);
    }

    public async Task<int> GetPatientId(string firstName, string lastName, DateOnly birthDate)
    {
        var id = await _context.Patients.Where(p =>
                p.FirstName == firstName && p.LastName == lastName && p.BirthDate == birthDate).Select(p => p.IdPatient)
            .FirstOrDefaultAsync();
        return id;
    }

    public async Task AddPatient(string firstName, string lastName, DateOnly birthDate)
    {
        await _context.Patients.AddAsync(new Patient()
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate
        });
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentExist(int id)
    {
        return (await _context.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == id)) != null;
    }

    public async Task AddPrescription(CreatePrescriptionDto prescription)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.Prescriptions.AddAsync(new Prescription()
            {
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                IdPatient = prescription.Patient.IdPatient,
                IdDoctor = prescription.IdDoctor
            });
            await _context.SaveChangesAsync();
            var prescriptionTemp = await _context.Prescriptions
                .Where(p => p.Date == prescription.Date && p.DueDate == prescription.DueDate 
                && p.Patient.IdPatient == prescription.Patient.IdPatient && p.IdDoctor == prescription.IdDoctor)
                .FirstAsync();
            prescription.IdPrescription = prescriptionTemp.IdPrescription;

            foreach (var medicament in prescription.Medicaments)
            {
                await _context.PrescriptionMedicaments.AddAsync(new PrescriptionMedicament()
                {
                    IdMedicament = medicament.IdMedicament,
                    IdPrescription = prescription.IdPrescription.Value,
                    Dose = medicament.Dose,
                    Details = medicament.Details
                });
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DoesDoctorExist(int id)
    {
        return (await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == id)) != null;
    }
}