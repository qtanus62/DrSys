﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrSys.Data;
using DrSys.Models;

namespace DrSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DrSysContext _context;

        public DoctorController(DrSysContext context)
        {
            _context = context;
        }

        public class DrSummary
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string SpecName { get; set; }
            public int AverageRating { get; set; }

        }

        // GET: api/Doctor
        // get doctor summary
        [HttpGet]
        public IEnumerable<DrSummary> GetDoctors()
        {
            /*SQL used to get Doctor summary data:
             * select dr.Name, dr.Gender, spec.SpecName, avg(patRating.Rating)
                from Doctors dr
                left join DoctorSpecialties drSpec on drSpec.DoctorId = dr.Id
                left join Specialties spec on spec.Id = drSpec.SpecialtyId
                left join PatientRatings patRating on patRating.DoctorId = dr.Id
                group by dr.Name, dr.Gender, spec.SpecNAme
            */
            var drs = from d in _context.Doctors
                   join drSpec in _context.DoctorSpecialties
                     on d.Id equals drSpec.DoctorId
                   join spec in _context.Specialties
                     on drSpec.SpecialtyId equals spec.Id
                   join patRating in _context.PatientRatings
                     on d.Id equals patRating.DoctorId
                   //group d by d.Name into dgroup
                   select new DrSummary
                   {
                       Name = d.Name,
                       Gender = d.Gender,
                       SpecName = spec.SpecName,
                       AverageRating = patRating.Rating

                   };

            //LAMBDA
            var drs2 = _context.Doctors
                .Join(_context.DoctorSpecialties, dr => dr.Id, drSpec => drSpec.DoctorId, (dr, drSpec) => new { Doctors = dr, DoctorSpecialty = drSpec })
                .Join(_context.Specialties, x => x.DoctorSpecialty.SpecialtyId, sp => sp.Id, (x, sp) => new { x, sp })
                //.Join(_context.PatientRatings, y => y.Doctor.Id, pr => pr.DoctorId, (y, pr) => new { y, PatientRating = pr })
                //.Where( r)
                //.GroupBy(x => new { x.dr.Name, x.dr.Gender })
                .Select(g => new DrSummary
                {
                    //g.Key.Name,
                    //g.Key.Gender,
                });



            return drs;
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor([FromRoute] int id, [FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctor
        [HttpPost]
        public async Task<IActionResult> PostDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok(doctor);
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}