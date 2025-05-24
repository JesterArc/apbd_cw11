using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class PatientWithPrescriptionsDto
{
    public PatientDto Patient { get; set; }
    public ICollection<PrescriptionDto> Prescriptions { get; set; }
}