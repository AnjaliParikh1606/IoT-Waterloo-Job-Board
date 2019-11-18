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
    public class CompanyDetailController : Controller
    {
        private readonly JobBoardContext _context;

        public CompanyDetailController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: CompanyDetail
        public async Task<IActionResult> Index()
        {
            var jobBoardContext = _context.CompanyDetails.Include(c => c.Role).Include(c => c.UserNameNavigation);
            return View(await jobBoardContext.ToListAsync());
        }

        // GET: CompanyDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetails = await _context.CompanyDetails
                .Include(c => c.Role)
                .Include(c => c.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyDetails == null)
            {
                return NotFound();
            }

            return View(companyDetails);
        }

        // GET: CompanyDetail/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType");
            ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName");
            return View();
        }

        // POST: CompanyDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,CompanyAddress,CompanyCity,CompanyPostalCode,CompanyLandLinePhoneNumber,CompanyLandLineExtensionNumber,CompanyEmailId,CompanyRegistrationDateTime,CompanyContactPerson,RoleId,UserName")] CompanyDetails companyDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", companyDetails.RoleId);
            ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", companyDetails.UserName);
            return View(companyDetails);
        }

        // GET: CompanyDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetails = await _context.CompanyDetails.FindAsync(id);
            if (companyDetails == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", companyDetails.RoleId);
            ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", companyDetails.UserName);
            return View(companyDetails);
        }

        // POST: CompanyDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,CompanyAddress,CompanyCity,CompanyPostalCode,CompanyLandLinePhoneNumber,CompanyLandLineExtensionNumber,CompanyEmailId,CompanyRegistrationDateTime,CompanyContactPerson,RoleId,UserName")] CompanyDetails companyDetails)
        {
            if (id != companyDetails.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyDetailsExists(companyDetails.CompanyId))
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
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", companyDetails.RoleId);
            ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", companyDetails.UserName);
            return View(companyDetails);
        }

        // GET: CompanyDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetails = await _context.CompanyDetails
                .Include(c => c.Role)
                .Include(c => c.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyDetails == null)
            {
                return NotFound();
            }

            return View(companyDetails);
        }

        // POST: CompanyDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyDetails = await _context.CompanyDetails.FindAsync(id);
            _context.CompanyDetails.Remove(companyDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyDetailsExists(int id)
        {
            return _context.CompanyDetails.Any(e => e.CompanyId == id);
        }
    }
}
