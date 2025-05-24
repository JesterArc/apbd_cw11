using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@gmail.com" },
            new Doctor() { IdDoctor = 2, FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com"},
            new Doctor() { IdDoctor = 3, FirstName = "Dr.", LastName = "Dre", Email = "dr.doe@gmail.com"}
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient() { IdPatient = 1,  FirstName = "Jan", LastName = "Krakowski", BirthDate = new DateOnly(2000, 8, 10) },
            new Patient() { IdPatient = 2,  FirstName = "Anna", LastName = "Kowal", BirthDate = new DateOnly(1998, 5, 24) },
            new Patient() { IdPatient = 3,  FirstName = "Wiedzimin", LastName = "Tyrzeci", BirthDate = new DateOnly(1986, 12, 1) }
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament() {IdMedicament = 1, Name = "EPEP", Description = "For a headache", Type = "Analgesic"},
            new Medicament() {IdMedicament = 2, Name = "Bogos", Description = "For restlessness", Type = "Sedative"},
            new Medicament() {IdMedicament = 3, Name = "AntiSneezonator", Description = "For a runny nose", Type = "Antihistamine"}
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription()
            {
                IdPrescription = 1, Date = new DateTime(2000, 8, 10), 
                DueDate = new DateTime(2001, 1, 1), IdPatient = 1, IdDoctor = 3
            },
            new Prescription()
            {
                IdPrescription = 2, Date = new DateTime(2001, 5, 12), 
                DueDate = new DateTime(2001, 5, 31), IdPatient = 2, IdDoctor = 1
            },
            new Prescription()
            {
            IdPrescription = 3, Date = new DateTime(2002, 3, 11), 
            DueDate = new DateTime(2003, 9, 27), IdPatient = 3, IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 4, Date = new DateTime(2007, 4, 14), 
                DueDate = new DateTime(2008, 2, 29), IdPatient = 3, IdDoctor = 2
            }
        });
        
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament()
            {
                IdMedicament = 2, IdPrescription = 1, Dose = 1, Details = "Once per day before sleep"
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 3, IdPrescription = 2, Dose = 3, Details = "Thrice per day after eating"
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 1, IdPrescription = 3, Dose = 2, Details = "Twice per week"
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 1, IdPrescription = 4, Details = "Twice per week"
            }
        });
    }
}