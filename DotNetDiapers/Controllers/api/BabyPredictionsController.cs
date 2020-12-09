using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetDiapers.Data;
using DotNetDiapers.Models;

namespace DotNetDiapers.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyPredictionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BabyPredictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BabyPredictions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabyPrediction>>> GetBabyPredictions()
        {
            return await _context.BabyPredictions.ToListAsync();
        }

        // GET: api/BabyPredictions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BabyPrediction>> GetBabyPrediction(int id)
        {
            var babyPrediction = await _context.BabyPredictions.FindAsync(id);

            if (babyPrediction == null)
            {
                return NotFound();
            }

            return babyPrediction;
        }

        // PUT: api/BabyPredictions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBabyPrediction(int id, BabyPrediction babyPrediction)
        {
            if (id != babyPrediction.Id)
            {
                return BadRequest();
            }

            _context.Entry(babyPrediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BabyPredictionExists(id))
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

        // POST: api/BabyPredictions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BabyPrediction>> PostBabyPrediction(BabyPrediction babyPrediction)
        {
            _context.BabyPredictions.Add(babyPrediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBabyPrediction", new { id = babyPrediction.Id }, babyPrediction);
        }

        // DELETE: api/BabyPredictions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BabyPrediction>> DeleteBabyPrediction(int id)
        {
            var babyPrediction = await _context.BabyPredictions.FindAsync(id);
            if (babyPrediction == null)
            {
                return NotFound();
            }

            _context.BabyPredictions.Remove(babyPrediction);
            await _context.SaveChangesAsync();

            return babyPrediction;
        }

        private bool BabyPredictionExists(int id)
        {
            return _context.BabyPredictions.Any(e => e.Id == id);
        }
    }
}
