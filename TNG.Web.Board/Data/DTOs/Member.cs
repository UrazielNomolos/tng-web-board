﻿#nullable disable
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TNG.Web.Board.Data.DTOs
{
    public enum MemberType
    {
        Member,
        Guest,
        Honorary
    }

    [Index(nameof(EmailAddress), IsUnique = true)]
    [Index(nameof(SceneName), nameof(LegalName))]
    public class Member
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public MemberType MemberType { get; set; }
        [Required]
        public bool HasAttendedSocial { get; set; } = false;
        [Required]
        public string LegalName { get; set; }
        [Required]
        public string SceneName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public bool ReceivedProofOfCovid19Vaccination { get; set; } = false;

        public virtual IQueryable<MembershipPayment> Payments { get; set; }
        public virtual IQueryable<MembershipSuspension> Suspensions { get; set; }
        public virtual IQueryable<MembershipNote> Notes { get; set; }
        public virtual IQueryable<MembershipOrientation> Orientations { get; set; }
    }
}
