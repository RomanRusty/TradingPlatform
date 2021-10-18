using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TradingPlatform.DataAccess;
using TradingPlatform.DataAccess.Repository;
namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsApiController : ControllerBase
    {
        private readonly IGenericUnitOfWork _context;

        public ComplaintsApiController(IGenericUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/ComplaintsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaints()
        {
            return Ok(await _context.Repository<Complaint>().GetAllAsync());
        }

        // GET: api/ComplaintsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(int id)
        {
            var complaint = await _context.Repository<Complaint>().FindByIdAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }
            return Ok(complaint);
        }

        // PUT: api/ComplaintsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint(int id, Complaint complaint)
        {
            if (id != complaint.Id)
            {
                return BadRequest();
            }
            try
            {
                await _context.Repository<Complaint>().UpdateAsync(complaint);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Repository<Complaint>().Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ComplaintsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Complaint>> PostComplaint(Complaint complaint)
        {
            await _context.Repository<Complaint>().AddAsync(complaint);
            return CreatedAtAction("GetComplaint", new { id = complaint.Id }, complaint);
        }

        // DELETE: api/ComplaintsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var category = await _context.Repository<Complaint>().FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _context.Repository<Complaint>().RemoveAsync(category);
            return NoContent();
        }
    }
}
