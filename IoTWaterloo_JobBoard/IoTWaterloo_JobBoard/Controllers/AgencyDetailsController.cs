using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IoTWaterloo_JobBoard.Models;

namespace IoTWaterloo_JobBoard.Controllers
{
    public class AgencyDetailsController : Controller
    {
        private readonly JobBoardContext _context;

        public AgencyDetailsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: AgencyDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgencyDetails.ToListAsync());
        }

        // GET: AgencyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyDetails = await _context.AgencyDetails
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (agencyDetails == null)
            {
                return NotFound();
            }

            return View(agencyDetails);
        }

        // GET: AgencyDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgencyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgencyId,AgencyName,AgencyWebsite,AgencyPhone,AgencyEmail")] AgencyDetails agencyDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencyDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agencyDetails);
        }

        // GET: AgencyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyDetails = await _context.AgencyDetails.FindAsync(id);
            if (agencyDetails == null)
            {
                return NotFound();
            }
            return View(agencyDetails);
        }

        // POST: AgencyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgencyId,AgencyName,AgencyWebsite,AgencyPhone,AgencyEmail")] AgencyDetails agencyDetails)
        {
            if (id != agencyDetails.AgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agencyDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencyDetailsExists(agencyDetails.AgencyId))
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
            return View(agencyDetails);
        }

        // GET: AgencyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencyDetails = await _context.AgencyDetails
                .FirstOrDefaultAsync(m => m.AgencyId == id);
            if (agencyDetails == null)
            {
                return NotFound();
            }

            return View(agencyDetails);
        }

        // POST: AgencyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencyDetails = await _context.AgencyDetails.FindAsync(id);
            _context.AgencyDetails.Remove(agencyDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyDetailsExists(int id)
        {
            return _context.AgencyDetails.Any(e => e.AgencyId == id);
        }
    }
}
