using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsApiController : DefaultApiController
    {
        // GET: api/ComplaintsApi
        [HttpGet]
        [ProducesResponseType(typeof(ComplaintReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ComplaintReadDto>>> GetComplaints()
        {
            var complaints = await ServiceManager.ComplaintService.GetAllAsync();

            return Ok(complaints);
        }

        // GET: api/ComplaintsApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ComplaintReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ComplaintReadDto>> GetComplaint(int id)
        {
            var complaint = await ServiceManager.ComplaintService.GetByIdAsync(id);

            return Ok(complaint);
        }

        // PUT: api/ComplaintsApi/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateComplaint(int id, ComplaintCreateDto complaintCreateDto)
        {
            await ServiceManager.ComplaintService.UpdateAsync(id, complaintCreateDto);

            return Ok();
        }

        // POST: api/ComplaintsApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ComplaintReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ComplaintReadDto>> CreateComplaint([FromBody] ComplaintCreateDto complaintCreateDto)
        {
            var complaint = await ServiceManager.ComplaintService.CreateAsync(complaintCreateDto);

            return Ok(complaint);
        }

        // DELETE: api/ComplaintsApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ComplaintReadDto), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            await ServiceManager.ComplaintService.DeleteAsync(id);

            return NoContent();
        }
        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<ComplaintReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ComplaintReadDto>>> GetBySearchFilterAsync([FromBody] ComplaintSearchDto filter)
        {
            var complaints = await ServiceManager.ComplaintService.FindBySearchAsync(filter);

            return Ok(complaints);
        }
    }
}
