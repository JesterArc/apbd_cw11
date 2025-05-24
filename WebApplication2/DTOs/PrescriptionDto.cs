namespace WebApplication2.DTOs;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public ICollection<PrescriptionMedicamentDto> Medicaments { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}