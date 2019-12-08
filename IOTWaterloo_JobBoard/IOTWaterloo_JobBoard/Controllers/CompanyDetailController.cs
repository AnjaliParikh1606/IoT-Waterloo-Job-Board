using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IOTWaterloo_JobBoard.Models;
using Microsoft.AspNetCore.Http;

namespace IOTWaterloo_JobBoard.Controllers
{
    public class CompanyDetailController : Controller
    {

        /// <summary>
        /// Author:Anjali Parikh
        /// </summary>
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
        public IActionResult CreateCompany()
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
        public async Task<IActionResult> CreateCompany([Bind("CompanyId,CompanyName,CompanyAddress,CompanyCity,CompanyPostalCode,CompanyLandLinePhoneNumber,CompanyLandLineExtensionNumber,CompanyEmailId,CompanyRegistrationDateTime,CompanyContactPerson,RoleId,UserName")] CompanyDetails companyDetails)
        {
            try 
            {
                if (ModelState.IsValid)
                {

                    _context.Add(companyDetails);
                    await _context.SaveChangesAsync();
                    TempData["success"] = true;
                    return View(companyDetails);
                }
                ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", companyDetails.RoleId);
                ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", companyDetails.UserName);
                return View(companyDetails);
            } catch (Exception Ex)
            {
                ViewData["ErrorMessage"] = Ex.InnerException.Message;
                return View(companyDetails);
            }
            
           
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
        public async Task<IActionResult> Create([Bind("UserName,Password,RoleId")] AccountInformation acinfo, [Bind("CompanyId,CompanyName,CompanyAddress,CompanyCity,CompanyPostalCode,CompanyLandLinePhoneNumber,CompanyLandLineExtensionNumber,CompanyEmailId,CompanyRegistrationDateTime,CompanyContactPerson,RoleId,UserName")] CompanyDetails cdetails, string confirmEmail, string confirmPass)
        {
            if (confirmEmail != cdetails.CompanyEmailId)
            {
                ModelState.AddModelError("confirmEmail", "Email ID does not match");
                return View();
            }
            if (confirmPass != acinfo.Password)
            {

                ModelState.AddModelError("confirmPass", "Password does not match");
                return View();
            }
            cdetails.UserName = cdetails.CompanyEmailId;
            // cdetails.RoleId = 2;

            if (_context.CompanyDetails.Any(a => a.UserName == cdetails.UserName))
            {
                ModelState.AddModelError("confirmEmail", "Email id already exist");
                return View();
            }
            if (ModelState.IsValid)
            {

                cdetails.RoleId = 2;
                _context.Add(cdetails);
                //await _context.SaveChangesAsync();
                acinfo.UserName = cdetails.CompanyEmailId;
                acinfo.RoleId = cdetails.RoleId;
                _context.AccountInformation.Add(acinfo);
                await _context.SaveChangesAsync();
                TempData["success"] = "Account created successfully";
                return RedirectToAction("Login", "AccountInformations");


            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", cdetails.RoleId);
            ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", cdetails.UserName);
            return View(cdetails);
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


            try {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(companyDetails);
                        TempData["success"] = true;
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
                    return RedirectToAction("Details", "CompanyDetail", new { @id = companyDetails.CompanyId });
                }
                ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", companyDetails.RoleId);
                ViewData["UserName"] = new SelectList(_context.AccountInformation, "UserName", "UserName", companyDetails.UserName);
                return View(companyDetails);
            }
            catch (Exception Ex)
            {

                ViewData["ErrorMessage"] = Ex.GetBaseException().Message;
                return View("Create", "CompanyDetails");
            }

            
        }


        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("companyid").ToString());
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
        public async Task<IActionResult> Profile(int id, [Bind("CompanyId,CompanyName,CompanyAddress,CompanyCity,CompanyPostalCode,CompanyLandLinePhoneNumber,CompanyLandLineExtensionNumber,CompanyEmailId,CompanyRegistrationDateTime,CompanyContactPerson,RoleId,UserName")] CompanyDetails companyDetails)
        {
            //if (id != companyDetails.CompanyId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    companyDetails.RoleId = 2;
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
                if (HttpContext.Session.GetString("roleid").ToString() == "1")
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
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
