using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC.TickerQ.Common;
using POC.TickerQ.Common.Entities;
using System;

namespace POC.TickerQ.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VersionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> InsertVersion([FromBody] VersionEntity version)
        {
            version.EffectiveFromDate = DateTime.UtcNow;
            _context.Versions.Add(version);
            await _context.SaveChangesAsync();
            return Ok(version);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var version = await _context.Versions.FindAsync(id);
            if (version == null) return NotFound();
            return Ok(version);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Versions.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVersion()
        {

            var existingVersion = _context.Versions.OrderByDescending(i => i.Id).FirstOrDefault();
            if (existingVersion == null)
            {
                return NotFound();
            }

            existingVersion.IsActive = true;

            _context.Versions.Update(existingVersion);
            await _context.SaveChangesAsync();

            return Ok(existingVersion);
        }

    }

}
