using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Contracts.Complaint;

namespace TradingPlatform.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsApiController : DefaultApiController
    {
        // GET: api/ComplaintsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplaintReadDto>>> GetComplaints()
        {
            var complaints = await ServiceManager.ComplaintService.GetAllAsync();

            return Ok(complaints);
        }

        // GET: api/ComplaintsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComplaintReadDto>> GetComplaint(int id)
        {
            var complaint = await ServiceManager.ComplaintService.GetByIdAsync(id);

            return Ok(complaint);
        }

        // PUT: api/ComplaintsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplaint(int id, ComplaintCreateDto complaintCreateDto)
        {
            await ServiceManager.ComplaintService.UpdateAsync(id, complaintCreateDto);

            return NoContent();
        }

        // POST: api/ComplaintsApi
       
        public async Task<ActionResult<ComplaintReadDto>> CreateComplaint([FromBody] ComplaintCreateDto complaintCreateDto)
        {
            var complaintReadDto = await ServiceManager.ComplaintService.CreateAsync(complaintCreateDto);

            return Ok(complaintReadDto);
        }

        // DELETE: api/ComplaintsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            await ServiceManager.ComplaintService.DeleteAsync(id);

            return NoContent();
        }
    }
}
