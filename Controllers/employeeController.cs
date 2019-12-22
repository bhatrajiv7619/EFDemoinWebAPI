using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFDemoinWebAPI.Data;
using EFDemoinWebAPI.Model;

namespace EFDemoinWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private readonly EFDemoinWebAPIContext _context;

        public employeeController(EFDemoinWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<employee>>> Getemployee()
        {
            return await _context.employee.ToListAsync();
        }

       
        // GET: api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<employee>> Getemployee(int id)
        {
            var employee = await _context.employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/employee/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemployee(int id, employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        /// <summary>
        /// Creates an employee.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /employee
        ///     {
        ///        "Name": "Surjan",
        ///        "Salary": "1234.50"
        ///     }
        ///
        /// </remarks>


        // POST: api/employee
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<employee>> Postemployee(employee employee)
        {
            _context.employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<employee>> Deleteemployee(int id)
        {
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool employeeExists(int id)
        {
            return _context.employee.Any(e => e.EmpId == id);
        }
    }
}
