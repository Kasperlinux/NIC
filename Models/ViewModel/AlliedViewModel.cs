﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIC.Models.ViewModel
{
    public class AlliedViewModel
    {
        [Key]
        [Column("Applicant_Id")]
        public int ApplicantId { get; set; }

        [Column("Aplicant_Name")]
        [StringLength(50)]
        public string? AplicantName { get; set; }

        [Column("DOB", TypeName = "date")]
        public DateTime? Dob { get; set; }

        [Column("Permanent_State")]
        public int? PermanentState { get; set; }

        [Column("Permanent_District")]
        public int? PermanentDistrict { get; set; }

        [Column("Permanent_Block")]
        public int? PermanentBlock { get; set; }

        [Column("Permanent_Village")]
        public int? PermanentVillage { get; set; }

        [Column("Permanent_Address")]
        [StringLength(50)]
        public string? PermanentAddress { get; set; }

        [Column("Present_State")]
        public int? PresentState { get; set; }

        [Column("Present_District")]
        public int? PresentDistrict { get; set; }

        [Column("Present_Block")]
        public int? PresentBlock { get; set; }

        [Column("Present_Village")]
        public int? PresentVillage { get; set; }

        [Column("Present_Address")]
        [StringLength(50)]
        public string? PresentAddress { get; set; }

        [Column("eMail")]
        [StringLength(100)]
        public string? EMail { get; set; }

        [StringLength(10)]
        public string? Mobile { get; set; }

        public int? Nationality { get; set; }

        public int? Category { get; set; }


        public char? Gender { get; set; }

        public int? Religion { get; set; }

        [Column("Passport_Photo", TypeName = "image")]
        public IFormFile? PassportPhoto { get; set; }

        [Column("PR_Cetificate")]
        public IFormFile? PrCetificate { get; set; }

        [Column("Category_Certificate")]
        public IFormFile? CategoryCertificate { get; set; }

        public IFormFile? AgeProof { get; set; }

        public IFormFile? Marksheet { get; set; }

        [Column("Character_Certificate")]
        public IFormFile? CharacterCertificate { get; set; }

        [Column("Guardian_Name")]
        [StringLength(50)]
        public string? GuardianName { get; set; }

        [Column("Guardian_Occupation")]
        [StringLength(100)]
        public string? GuardianOccupation { get; set; }

        [Column("Guardian_OfficeName")]
        [StringLength(100)]
        public string? GuardianOfficeName { get; set; }

        [Column("Guardian_OfficeAddress")]
        [StringLength(200)]
        public string? GuardianOfficeAddress { get; set; }

        [Column("Guardian_EmployerCertificate")]
        public IFormFile? GuardianEmployerCertificate { get; set; }

        [Column("marks_Physics_Theory")]
        public double? MarksPhysicsTheory { get; set; }

        [Column("marks_Physics_Practical")]
        public double? MarksPhysicsPractical { get; set; }

        [Column("fullmarks_Physics")]
        public double? FullmarksPhysics { get; set; }

        [Column("marks_Chemistry_Theory")]
        public double? MarksChemistryTheory { get; set; }

        [Column("marks_Chemistry_Practical")]
        public double? MarksChemistryPractical { get; set; }

        [Column("fullmarks_Chemistry")]
        public double? FullmarksChemistry { get; set; }

        [Column("marks_Biology_Theory")]
        public double? MarksBiologyTheory { get; set; }

        [Column("marks_Biology_Practical")]
        public double? MarksBiologyPractical { get; set; }

        [Column("fullmarks_Biology")]
        public double? FullmarksBiology { get; set; }

        [Column("marks_English_Theory")]
        public double? MarksMathematicsTheory { get; set; }

        [Column("marks_English_Practical")]
        public double? MarksMathematicsPractical { get; set; }

        [Column("fullmarks_English")]
        public double? FullmarksMathematics { get; set; }

        [Column("Percentage_XII")]
        public double? PercentageXii { get; set; }

        [Column("Percentage_PCB_XII")]
        public double? PercentagePcbXii { get; set; }

        [Column("Percentage_PCBE_XII")]
        public double? PercentagePcmXii { get; set; }

        public int? ScreeningCentre { get; set; }

        public int? ApplicationStatus { get; set; }

        [StringLength(100)]
        public string? Remarks { get; set; }

        [Column("DataEntry_Timestamp", TypeName = "datetime")]
        public DateTime? DataEntryTimestamp { get; set; }

        [Column("DataEntry_IP")]
        [StringLength(20)]
        public string? DataEntryIp { get; set; }

        [Column("Modified_By")]
        public int? ModifiedBy { get; set; }

        [Column("Modified_Timestamp", TypeName = "datetime")]
        public DateTime? ModifiedTimestamp { get; set; }

        [Column("Modified_IP")]
        [StringLength(20)]
        public string? ModifiedIp { get; set; }

        public int? AgeAsOnCutOffDate { get; set; }
    }
}
