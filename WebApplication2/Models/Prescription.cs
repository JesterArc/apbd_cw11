using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[PrimaryKey(nameof(IdPrescription))]
public class Prescription
{
    public int IdPrescription { get; set; }
    [Column(TypeName = "Date")]
    public DateOnly Date { get; set; }
    [Column(TypeName = "Date")]
    public DateOnly DueDate { get; set; }
    [ForeignKey(nameof(Patient))]
    public int IdPatient { get; set; }
    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}