﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[PrimaryKey(nameof(IdDoctor))]
public class Doctor
{
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}