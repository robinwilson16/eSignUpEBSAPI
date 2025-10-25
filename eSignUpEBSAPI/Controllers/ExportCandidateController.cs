using eSignUpEBSAPI.Interfaces;
using eSignUpEBSAPI.Models.ExportCandidates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eSignUpEBSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ExportCandidateController : ControllerBase
    {
        private readonly IExportCandidateService _apiService;

        public ExportCandidateController(IExportCandidateService apiService)
        {
            _apiService = apiService;
        }

        public CandidateModel? Record { get; set; }
        //Use IEnumerable for multiple records in Controller and List in Service to allow use of .AddRange
        public IEnumerable<CandidateModel>? Records { get; set; }

        //[HttpGet]
        ////Sycronous version
        //public ActionResult<IEnumerable<CandidateModel>?> GetAll() =>
        //    _apiService.GetAll();

        //[Authorize]
        [HttpGet]
        //Asynchronous version
        public async Task<IActionResult> GetAllAsync()
        {
            var records = await _apiService.GetAllAsync();
            if (records == null || !records.Any())
                return NotFound("No records available");

            return Ok(records);
        }

        //[Authorize]
        ////Sycronous version
        //[HttpGet("{recordID}")]
        //public ActionResult<CandidateModel> Get(int recordID)
        //{
        //    if (recordID <= 0)
        //        return BadRequest("Invalid ID Supplied");

        //    var record = _apiService.Get(recordID);

        //    if (record == null)
        //        return NotFound("Record Not Found");

        //    return Ok(record);
        //}

        [HttpGet("{recordID}")]
        //Asynchronous version
        public async Task<IActionResult> GetAsync(int recordID)
        {
            if (recordID <= 0)
                return BadRequest("Invalid ID Supplied");

            var record = await _apiService.GetAsync(recordID);

            if (record == null)
                return NotFound("Record Not Found");

            return Ok(record);
        }

        //[HttpGet("Many")]
        ////Syncronous version
        //public ActionResult<IEnumerable<CandidateModel>> GetMany([FromQuery] IEnumerable<int>? ids)
        //{
        //    if (ids == null || !ids.Any())
        //        return BadRequest("Provide one or more ids, e.g. ?IDs=1,2,3 or ?IDs=1&IDs=2");

        //    var records = _apiService.GetMany(ids);
        //    if (records == null || !records.Any())
        //        return NotFound("No Records Found");

        //    return Ok(records);
        //}

        [HttpGet("Many")]
        //Asynchronous version
        public async Task<IActionResult> GetManyAsync([FromQuery] IEnumerable<int>? ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("Provide one or more ids, e.g. ?IDs=1,2,3 or ?IDs=1&IDs=2");

            var records = await _apiService.GetManyAsync(ids);
            if (records == null || !records.Any())
                return NotFound("No Records Found");

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateModel newRecord)
        {
            if (newRecord == null)
                return BadRequest("No Record Supplied");

            //Check this record does not already exist
            var existingRecord = await _apiService.GetAsync(newRecord.ID);

            if (existingRecord is not null)
                return BadRequest("Record Already Exists");

            if (newRecord.ID > 0)
                Record = await _apiService.AddWithID(newRecord);
            else
                Record = await _apiService.Add(newRecord);

            if (Record is null)
                return BadRequest("Unable to Create Record");

            Console.WriteLine($"\nCreated Record ID: {Record.ID}");
            var location = Url.Action(nameof(GetAsync), "ExportCandidate", new { recordID = Record.ID }, Request.Scheme);

            return Created(location ?? string.Empty, Record);
        }

        [HttpPost("Many")]
        public async Task<IActionResult> CreateMany(IEnumerable<CandidateModel> newRecords)
        {
            if (newRecords == null || !newRecords.Any())
                return BadRequest("No Records Supplied");

            if (newRecords.Any(r => r.ID > 0))
                Records = await _apiService.AddManyWithID((List<CandidateModel>)newRecords);
            else
                Records = await _apiService.AddMany((List<CandidateModel>)newRecords);

            var ids = string.Join(",", newRecords.Select(r => r.ID));

            if (Records is null || !Records.Any())
                return BadRequest("Unable to Create Records");

            Console.WriteLine($"\nCreated Record IDs: {Records.Select(r => r.ID).ToArray()}");
            var location = Url.Action(nameof(GetManyAsync), "ExportCandidate", new { ids = Records.Select(r => r.ID).ToArray() }, Request.Scheme);

            return Created(location ?? string.Empty, Records);
        }

        //[Authorize]
        [HttpPut("{recordID}")]
        public async Task<IActionResult> Update(int recordID, CandidateModel updatedRecord)
        {
            if (updatedRecord == null)
                return BadRequest("No Record Supplied");

            //Check record being updated matches the ID in the URL
            if (recordID != updatedRecord.ID)
                return BadRequest("Wrong Record Being Updated");

            var currentRecord = await _apiService.GetAsync(recordID);
            if (currentRecord is null)
                return NotFound("Record Does Not Exist");

            Record = await _apiService.Update(updatedRecord, true);
            if (Record is null)
                return BadRequest("Unable to Update Record");

            Console.WriteLine($"\nUpdated Record ID: {Record.ID}");
            var location = Url.Action(nameof(GetAsync), "ExportCandidate", new { recordID = Record.ID }, Request.Scheme);

            return Accepted(location ?? string.Empty, Record);
        }

        //[Authorize]
        [HttpPut("Many")]
        public async Task<IActionResult> UpdateMany(IEnumerable<CandidateModel> updatedRecords)
        {
            if (updatedRecords == null)
                return BadRequest("No Records Supplied");

            var currentRecords = await _apiService.GetManyAsync(updatedRecords.Select(r => r.ID)!);
            if (currentRecords == null || !currentRecords.Any())
                return NotFound("No Records Found to Update");

            Records = await _apiService.UpdateMany((List<CandidateModel>?)updatedRecords);
            if (Records is null || !Records.Any())
                return BadRequest("Unable to Update Records");

            Console.WriteLine($"\nUpdated Record IDs: {Records.Select(r => r.ID).ToArray()}");
            var location = Url.Action(nameof(GetManyAsync), "ExportCandidate", new { ids = Records.Select(r => r.ID).ToArray() }, Request.Scheme);

            return Accepted(location ?? string.Empty, Records);
        }

        //[Authorize]
        [HttpDelete("{recordID}")]
        public async Task<IActionResult> Delete(int recordID)
        {
            if (recordID <= 0)
                return BadRequest("Invalid ID Supplied");

            var deletedRecord = await _apiService.GetAsync(recordID);

            if (deletedRecord is null)
                return NotFound("Record Not Found. It May Have Already Been Deleted");

            Record = await _apiService.Delete(recordID);

            if (Record is null)
                return BadRequest("Unable to Delete Record");

            Console.WriteLine($"\nDeleted Record ID: {Record.ID}");
            var location = Url.Action(nameof(GetAsync), "ExportCandidate", new { recordID = Record.ID }, Request.Scheme);

            return Accepted(location ?? string.Empty, Record);
        }

        //[Authorize]
        [HttpDelete("Many")]
        public async Task<IActionResult> DeleteMany(IEnumerable<CandidateModel> recordsToDelete)
        {
            if (recordsToDelete == null || !recordsToDelete.Any())
                return BadRequest("No Records Supplied");

            if (recordsToDelete == null)
                return BadRequest();

            Records = await _apiService.DeleteMany((List<CandidateModel>?)recordsToDelete);
            if (Records is null || !Records.Any())
                return BadRequest("Unable to Delete Records");

            Console.WriteLine($"\nDeleted Record IDs: {Records.Select(r => r.ID).ToArray()}");
            var location = Url.Action(nameof(GetManyAsync), "ExportCandidate", new { ids = Records.Select(r => r.ID).ToArray() }, Request.Scheme);

            return Accepted(location ?? string.Empty, Records);
        }

        //[Authorize]
        [HttpDelete("All/{confirm}")]
        public async Task<IActionResult> DeleteAll(string confirm)
        {
            if (confirm != "Y")
                return BadRequest("The Request Needs To Be Confirmed with Y");

            Records = await _apiService.DeleteAll();
            if (Records is null || !Records.Any())
                return BadRequest("Unable to Delete Records");

            //return AcceptedAtAction(nameof(GetAllAsync), new { }, null);
            return NoContent();
        }

        [HttpGet("Schema")]
        public async Task<IActionResult> GetSchema()
        {
            var schema = await _apiService.GetSchema();
            if (schema == null || !schema.Any())
                return NotFound("No schema information available");

            return Ok(schema);
        }
    }
}
