using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class PatientDto
{
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}

