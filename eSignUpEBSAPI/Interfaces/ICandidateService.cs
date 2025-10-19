using eSignUpEBSAPI.Models;

namespace eSignUpEBSAPI.Interfaces
{
    public interface ICandidateService
    {
        // Properties (optional - expose read-only)
        List<CandidateModel>? Candidates { get; }
        CandidateModel? Candidate { get; }

        // Async retrieval backed by stored-proc or DB
        Task<List<CandidateModel>?> GetAllAsync();
        List<CandidateModel>? GetAll();

        Task<CandidateModel?> GetAsync(int recordID);
        CandidateModel? Get(int recordID);

        Task<List<CandidateModel>?> GetManyAsync(IEnumerable<int>? ids);
        List<CandidateModel>? GetMany(IEnumerable<int>? ids);

        // CRUD
        Task<CandidateModel?> Add(CandidateModel newRecord);
        Task<List<CandidateModel>?> AddMany(List<CandidateModel> newRecords);

        Task<CandidateModel?> Update(CandidateModel? updatedRecord, bool? save);
        Task<List<CandidateModel>?> UpdateMany(List<CandidateModel>? updatedRecords);

        Task<CandidateModel?> Delete(int recordID);
        Task<List<CandidateModel>?> DeleteMany(List<CandidateModel>? recordsToDelete);
        Task<List<CandidateModel>?> DeleteAll();

        // Metadata
        Task<List<SchemaModel>?> GetSchema();
    }
}