namespace WebApplication2.DTOs;

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public required string Details { get; set; }
}