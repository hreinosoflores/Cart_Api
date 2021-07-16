using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angular3_Api.EF;
using Angular3_Api.Models;

namespace Angular3_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsOrderController : ControllerBase
    {
        private readonly ApiContext _context;

        public DetailsOrderController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/DetailsOrder/get/all
        [HttpGet("get/all")]
        public async Task<ActionResult<IEnumerable<DetailOrder>>> GetDetailsOrder()
        {
            return await _context.DetailsOrder.ToListAsync();
        }



        // GET: api/DetailsOrder/get/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<DetailOrder>> GetDetailOrder(long id)
        {
            var detailOrder = await _context.DetailsOrder.FindAsync(id);

            if (detailOrder == null)
            {
                return NotFound();
            }

            return detailOrder;
        }

        // PUT: api/DetailsOrder/update/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutDetailOrder(long id, DetailOrder detailOrder)
        {
            if (id != detailOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(detailOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOrderExists(id))
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

        //POST: api/DetailsOrder/add
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add")]
        public async Task<ActionResult<DetailOrder>> PostDetailOrder(DetailOrder detailOrder)
        {
            _context.DetailsOrder.Add(detailOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailOrder", new { id = detailOrder.Id }, detailOrder);
        }



        // POST: api/DetailsOrder/add/batch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add/batch")]
        public async Task<ActionResult<IEnumerable<DetailOrder>>> PostDetailsInBatch(List<DetailOrder> details)
        {
            _context.DetailsOrder.AddRange(details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailsOrder", details);
        }


        // DELETE: api/DetailsOrder/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDetailOrder(long id)
        {
            var detailOrder = await _context.DetailsOrder.FindAsync(id);
            if (detailOrder == null)
            {
                return NotFound();
            }

            _context.DetailsOrder.Remove(detailOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailOrderExists(long id)
        {
            return _context.DetailsOrder.Any(e => e.Id == id);
        }
    }
}
