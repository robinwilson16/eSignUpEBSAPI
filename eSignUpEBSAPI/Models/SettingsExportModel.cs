using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace eSignUpEBSAPI.Models
{
    [Keyless]
    public class SettingsExportModel
    {
        public string? AcademicYear { get; set; }
        public int? CandidateRegistrationStatusID { get; set; }

        [StringLength(1)]
        public string? StudentType { get; set; }
    }
}
