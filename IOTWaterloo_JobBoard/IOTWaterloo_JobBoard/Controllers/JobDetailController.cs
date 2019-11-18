using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IOTWaterloo_JobBoard.Models;

namespace IOTWaterloo_JobBoard.Controllers
{
    public class JobDetailController : Controller
    {
        private readonly JobBoardContext _context;

        public JobDetailController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: JobDetail
        public async Task<IActionResult> Index()
        {
            var jobBoardContext = _context.JobDetails.Include(j => j.Compnay);
            return View(await jobBoardContext.ToListAsync());
        }

        // GET: JobDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetails = await _context.JobDetails
                .Include(j => j.Compnay)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobDetails == null)
            {
                return NotFound();
            }

            return View(jobDetails);
        }

        // GET: JobDetail/Create
        public IActionResult Create()
        {
            ViewData["CompnayId"] = new SelectList(_context.CompanyDetails, "CompanyId", "CompanyId");
            return View();
        }

        // POST: JobDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobTitle,Category,Location,Jobtype,MaxSalary,MinSalary,JobDescription,PayPeriod,NumberOfPosition,JobPostDate,JobExpiryDate,CompnayId")] JobDetails jobDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompnayId"] = new SelectList(_context.CompanyDetails, "CompanyId", "CompanyId", jobDetails.CompnayId);
            return View(jobDetails);
        }

        // GET: JobDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetails = await _context.JobDetails.FindAsync(id);
            if (jobDetails == null)
            {
                return NotFound();
            }
            ViewData["CompnayId"] = new SelectList(_context.CompanyDetails, "CompanyId", "CompanyId", jobDetails.CompnayId);
            return View(jobDetails);
        }

        // POST: JobDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobTitle,Category,Location,Jobtype,MaxSalary,MinSalary,JobDescription,PayPeriod,NumberOfPosition,JobPostDate,JobExpiryDate,CompnayId")] JobDetails jobDetails)
        {
            if (id != jobDetails.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDetailsExists(jobDetails.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompnayId"] = new SelectList(_context.CompanyDetails, "CompanyId", "CompanyId", jobDetails.CompnayId);
            return View(jobDetails);
        }

        // GET: JobDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDetails = await _context.JobDetails
                .Include(j => j.Compnay)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobDetails == null)
            {
                return NotFound();
            }

            return View(jobDetails);
        }

        // POST: JobDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobDetails = await _context.JobDetails.FindAsync(id);
            _context.JobDetails.Remove(jobDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobDetailsExists(int id)
        {
            return _context.JobDetails.Any(e => e.JobId == id);
        }
    }
}
