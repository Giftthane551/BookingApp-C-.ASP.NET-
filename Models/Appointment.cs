using System;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; set; }

    [MaxLength(50)]
    public string? AccountType { get; set; }

    [MaxLength(255)]
    public string? MedicalAid { get; set; }

    [MaxLength(255)]
    public string? MedicalAidOption { get; set; }

    [MaxLength(100)]
    public string? MembershipNumber { get; set; }

    [MaxLength(15)]
    public string? ContactDetails { get; set; }

    [MaxLength(15)]
    public string? AlternativeNumber { get; set; }

    [MaxLength(50)]
    public string? PatientInfo { get; set; }

    public DateTime CreatedDate { get; set; }
}
