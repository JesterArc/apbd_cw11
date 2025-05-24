using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreatePrescriptionDto
{
    public int? IdPrescription { get; set; }
    public PatientDto Patient { get; set; }
    public ICollection<MedicamentDto> Medicaments { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public int IdDoctor { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
}