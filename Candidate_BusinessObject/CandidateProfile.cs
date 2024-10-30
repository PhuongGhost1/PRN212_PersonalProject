using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candidate_BusinessObject;

public partial class CandidateProfile
{
    [Key]
    public string CandidateId { get; set; } = null!;
    [StringLength(100, MinimumLength = 12, ErrorMessage = "Full name must be at least 12 characters long.")]
    [RegularExpression(@"^([A-Z][a-z]*\s*)+$", ErrorMessage = "Each word must start with a capital letter.")]
    public string Fullname { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    [StringLength(200, MinimumLength = 2)]
    public string? ProfileShortDescription { get; set; }

    public string? ProfileUrl { get; set; }

    public string? PostingId { get; set; }

    public virtual JobPosting? Posting { get; set; }
}
