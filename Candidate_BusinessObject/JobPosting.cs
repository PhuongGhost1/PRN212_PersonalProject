using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candidate_BusinessObject;

public partial class JobPosting
{
    [Key]
    public string PostingId { get; set; } = null!;

    public string JobPostingTitle { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? PostedDate { get; set; }

    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();
}
