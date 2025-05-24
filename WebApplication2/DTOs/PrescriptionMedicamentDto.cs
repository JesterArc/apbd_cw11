using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public required string Details { get; set; }
}