using eSignUpEBSAPI.Data;
using eSignUpEBSAPI.Helpers;
using eSignUpEBSAPI.Interfaces;
using eSignUpEBSAPI.Models;
using eSignUpEBSAPI.Models.ExportCandidates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.ExternalConnectors;
using System.Data.Common;

namespace eSignUpEBSAPI.Services
{
    public class ExportCandidateService : IExportCandidateService
    {
        private readonly ExportCandidatesDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CandidateService> _logger;

        public List<CandidateModel>? Candidates { get; set; }
        public CandidateModel? Candidate { get; set; }

        public ExportCandidateService(
            ExportCandidatesDbContext context, 
            IConfiguration configuration,
            ILogger<CandidateService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;

            SettingsExportModel exportModel = new SettingsExportModel();
            exportModel = _configuration.GetSection("Export").Get<SettingsExportModel>() ?? new SettingsExportModel();

            string? academicYear = exportModel.AcademicYear;

            //Better to use async methods to avoid blocking and call stored procedure in body

            /*
            try
            {
                if (exportModel is not null && academicYear != null && candidateRegistrationStatusID > 0 && studentType != null)
                    Records = _context.Candidate!
                        //.Include(c => c.AnotherTable)
                        .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Candidate (AcademicYear: {academicYear}, CandidateRegistrationStatusID: {candidateRegistrationStatusID}, StudentType: {studentType})");
                throw; // let the middleware return a formatted response
            }
            */
        }

        public async Task<List<CandidateModel>?> GetAllAsync()
        {
            //Call this method if not pulling in synchronously in the constructor
            //Async is better for performance when dealing with large datasets

            try
            {
                Candidates = await _context.Candidate
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Candidates");
                throw; // let the middleware return a formatted response
            }

            return Candidates;
        }

        public List<CandidateModel>? GetAll() => Candidates;

        public async Task<CandidateModel?> GetAsync(int recordID)
        {

            try
            {
                Candidate = await _context.Candidate
                    .AsNoTracking()
                    .Where(c => c.ID == recordID)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Candidate: {recordID.ToString()})");
                throw; // let the middleware return a formatted response
            }

            return Candidate;
        }

        public CandidateModel? Get(int recordID) => Candidates?.FirstOrDefault(c => c.ID == recordID);

        public async Task<List<CandidateModel>?> GetManyAsync(IEnumerable<int>? ids)
        {
            if (ids == null || !ids.Any())
                return new List<CandidateModel>();

            var idsCsv = string.Join(",", ids);
            var idList = ids.ToList();

            try
            {
                Candidates = await _context.Candidate
                    .AsNoTracking()
                    .Where(c => idList.Contains(c.ID))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Candidates: {idsCsv})");
                throw; // let the middleware return a formatted response
            }

            return Candidates;
        }

        public List<CandidateModel>? GetMany(IEnumerable<int>? ids)
        {
            if (ids == null)
                return new List<CandidateModel>();

            var idList = ids.ToList();

            try
            {
                // Use cached Records if present otherwise query the DbContext.

                if (Candidates != null)
                    return Candidates.Where(r => idList.Contains(r.ID)).ToList();

                return _context.Candidate?
                    .Where(c => idList.Contains(c.ID))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Records by IDs ({string.Join(", ", idList)})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<CandidateModel?> Add(CandidateModel newRecord)
        {
            try 
            {
                _context.Candidate?.Add(newRecord);
                await _context.SaveChangesAsync();

                return newRecord;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding Record (ID: {newRecord?.StudentID})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<CandidateModel?> AddWithID(CandidateModel newRecord)
        {
            try
            {
                // If provider is SQL Server and the entity has an identity column,
                // enable IDENTITY_INSERT for the table while inserting explicit key values.
                if (_context.Database.IsSqlServer())
                {
                    await using var conn = _context.Database.GetDbConnection();
                    await conn.OpenAsync();
                    await using var transaction = await _context.Database.BeginTransactionAsync();

                    //Add missing IDs for navigation properties
                    if (newRecord.CandidateNotes != null)
                    {
                        foreach (var n in newRecord.CandidateNotes)
                        {
                            n.CandidateID = newRecord.ID;
                        }
                    }

                    if (newRecord.CandidateQualifications != null)
                    {
                        foreach (var q in newRecord.CandidateQualifications)
                        {
                            q.CandidateID = newRecord.ID;
                        }
                    }

                    var notesToInsert = newRecord.CandidateNotes?.ToList() ?? new List<CandidateNoteModel>();
                    var qualificationsToInsert = newRecord.CandidateQualifications?.ToList() ?? new List<CandidateQualificationModel>();

                    // Detach navigation properties from the candidate before adding it
                    newRecord.CandidateNotes = null;
                    newRecord.CandidateQualifications = null;

                    try
                    {
                        await DatabaseHelper.InsertWithIdentityAsync<CandidateModel>(_context, async () =>
                        {
                            _context.Candidate?.Add(newRecord);
                            await _context.SaveChangesAsync();
                        });

                        // Add Notes with explicit IDs if any
                        if (notesToInsert.Any())
                        {
                            await DatabaseHelper.InsertWithIdentityAsync<CandidateNoteModel>(_context, async () =>
                            {
                                await _context.Set<CandidateNoteModel>().AddRangeAsync(notesToInsert);
                                await _context.SaveChangesAsync();
                            });
                        }

                        // Add Qualifications with explicit IDs if any
                        if (notesToInsert.Any())
                        {
                            await DatabaseHelper.InsertWithIdentityAsync<CandidateQualificationModel>(_context, async () =>
                            {
                                await _context.Set<CandidateQualificationModel>().AddRangeAsync(qualificationsToInsert);
                                await _context.SaveChangesAsync();
                            });
                        }

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                    finally
                    {
                        await conn.CloseAsync();
                    }
                }
                else
                {
                    // Non-SQLServer providers won't support IDENTITY_INSERT; fall back to normal add
                    _context.Candidate?.Add(newRecord);
                    await _context.SaveChangesAsync();
                }

                return newRecord;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding Record (ID: {newRecord?.ID})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<List<CandidateModel>?> AddMany(List<CandidateModel> newRecords)
        {
            try
            {
                await _context.Candidate?.AddRangeAsync(newRecords)!;
                await _context.SaveChangesAsync();

                return newRecords;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding multiple Records (Count: {newRecords?.Count})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<List<CandidateModel>?> AddManyWithID(List<CandidateModel> newRecords)
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await using var conn = _context.Database.GetDbConnection();
                    await conn.OpenAsync();
                    await using var transaction = await _context.Database.BeginTransactionAsync();

                    try
                    {
                        await DatabaseHelper.InsertWithIdentityAsync<CandidateModel>(_context, async () =>
                        {
                            _context.Candidate?.AddRangeAsync(newRecords);
                            await _context.SaveChangesAsync();
                        });

                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                    finally
                    {
                        await conn.CloseAsync();
                    }
                }
                else
                {
                    await _context.Candidate!.AddRangeAsync(newRecords);
                    await _context.SaveChangesAsync();
                }

                return newRecords;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding multiple Records (Count: {newRecords?.Count})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<CandidateModel?> Update(CandidateModel? updatedRecord, bool? save)
        {
            try
            {
                //Include any related entities
                CandidateModel? currentRecord = _context.Candidate!
                    .FirstOrDefault(m => m.ID == updatedRecord!.ID);

                if (currentRecord == null)
                    return null!;

                //Update content of related entities
                //Need to get full related entity as only the ID is set in the updated record so causes the rest of the fields to be wiped out like description, etc.

                //if (updatedRecord?.MessageTemplate != null)
                //{
                //    var existingTemplate = await _context.MessageTemplate!
                //        .FirstOrDefaultAsync(t => t.MessageTemplateID == updatedRecord.MessageTemplate.MessageTemplateID);

                //    if (existingTemplate != null)
                //    {
                //        // Attach the existing MessageTemplate to the context
                //        _context.Entry(existingTemplate).State = EntityState.Unchanged;
                //        recordToUpdate.MessageTemplate = existingTemplate;
                //    }
                //}

                _context.Entry(currentRecord!).CurrentValues.SetValues(updatedRecord!);

                //Ensures related entities are included in the save operation
                _context?.Update(currentRecord);

                if (save != false)
                    await _context!.SaveChangesAsync();

                return currentRecord;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating Record (ID: {updatedRecord?.ID})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<List<CandidateModel>?> UpdateMany(List<CandidateModel>? updatedRecords)
        {
            try
            {
                if (updatedRecords is null)
                    return null!;

                foreach (var updatedRecord in updatedRecords)
                {
                    await Update(updatedRecord, false);
                }

                //Save all changes at the end to avoid multiple save operations
                await _context.SaveChangesAsync();

                return updatedRecords;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating multiple Records (Count: {updatedRecords?.Count})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<CandidateModel?> Delete(int recordID)
        {
            try
            {
                var recordToDelete = Get(recordID);
                if (recordToDelete is null)
                    return null!;

                _context.Candidate!.Remove(recordToDelete);
                await _context.SaveChangesAsync();

                return recordToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting Record (ID: {recordID})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<List<CandidateModel>?> DeleteMany(List<CandidateModel>? recordsToDelete)
        {
            try
            {
                if (recordsToDelete is null)
                    return null;

                //Check all records exist
                foreach (var recordToDelete in recordsToDelete)
                {
                    CandidateModel? recordToCheck = _context.Candidate!
                        .FirstOrDefault(c => c.ID == recordToDelete.ID);
                    if (_context.Candidate == null)
                    {
                        return null;
                    }
                    //Could check if other elements of the record match, e.g. StudentDetailID for student-related records
                    //else if (recordToCheck?.StudentDetailID != studentDetailID)
                    //{
                    //    return new APIResultModel() { IsSuccessful = false };
                    //}
                }

                _context.Candidate!.RemoveRange(recordsToDelete);
                await _context.SaveChangesAsync();

                return recordsToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting multiple Records (Count: {recordsToDelete?.Count})");
                throw; // let the middleware return a formatted response
            }
        }

        public async Task<List<CandidateModel>?> DeleteAll()
        {
            var recordsToDelete = GetAll();
            if (recordsToDelete is null)
                return null;

            await _context.Database.ExecuteSqlRawAsync("SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE Candidate;");

            return recordsToDelete;
        }

        public async Task<List<SchemaModel>?> GetSchema()
        {
            const string tableName = "Candidate";

            List<SchemaModel> schemaList = new List<SchemaModel>();

            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            try
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT TOP (0) * FROM [{tableName}]";
                cmd.CommandType = System.Data.CommandType.Text;

                

                using var reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.SchemaOnly | System.Data.CommandBehavior.KeyInfo);
                var cols = reader.GetColumnSchema();
                foreach (var c in cols)
                {
                    _logger.LogInformation("ColumnOrdinal={Ordinal}, ColumnName={Name}, DataTypeName={TypeName}, DataType={ClrType}",
                        c.ColumnOrdinal, c.ColumnName, c.DataTypeName, c.DataType);
                    schemaList.Add(new SchemaModel 
                    { 
                        ColumnOrdinal = c.ColumnOrdinal, 
                        ColumnName = c.ColumnName, 
                        DataTypeName = c.DataTypeName, 
                        DataType = c.DataType?.ToString() 
                    });
                }
            }
            finally
            {
                await conn.CloseAsync();
            }

            return schemaList;
        }
    }
}
