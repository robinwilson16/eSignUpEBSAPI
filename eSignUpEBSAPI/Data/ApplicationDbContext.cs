using Microsoft.EntityFrameworkCore;

namespace eSignUpEBSAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Models.CandidateModel> Candidate { get; set; }
        public DbSet<Models.CandidateDisabilityLearningDifficultyResultModel> CandidateDisabilityLearningDifficultyResult { get; set; }
        public DbSet<Models.CandidateDocumentModel> CandidateDocument { get; set; }
        public DbSet<Models.CandidateExtraFieldModel> CandidateExtraField { get; set; }
        public DbSet<Models.CandidateNoteModel> CandidateNote { get; set; }
        public DbSet<Models.CandidateQualificationModel> CandidateQualification { get; set; }
        public DbSet<Models.CustomFieldValueModel> CustomFieldValue { get; set; }
    }
}
