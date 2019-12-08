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
    public class AccountInformationsController : Controller
    {
        private readonly JobBoardContext _context;

        public AccountInformationsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: AccountInformations
        public async Task<IActionResult> Index()
        {
            var jobBoardContext = _context.AccountInformation.Include(a => a.Role);
            return View(await jobBoardContext.ToListAsync());
        }

        // GET: AccountInformations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInformation = await _context.AccountInformation
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (accountInformation == null)
            {
                return NotFound();
            }

            return View(accountInformation);
        }

        // GET: AccountInformations/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType");
            return View();
        }

        // POST: AccountInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,RoleId")] AccountInformation accountInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", accountInformation.RoleId);
            return View(accountInformation);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] AccountInformation accountInformation)
        {
            var user = await _context.AccountInformation.FindAsync(accountInformation.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "User not registered");
            }
            else
            {
                if (user.Password != accountInformation.Password)
                {
                    ModelState.AddModelError("Password", "Wrong Password");
                }
                else
                {
                    int roleid = user.RoleId;
                    if (roleid > 0)
                    {
                        TempData["Log"] = "Log in successful";
                        HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("emailid", user.UserName);
                        if (roleid == 2)
                        {
                            int cid = _context.CompanyDetails.Where(m => m.CompanyEmailId == user.UserName).FirstOrDefault().CompanyId;
                            if (cid > 0)
                            {

                                HttpContext.Session.SetString("companyid", cid.ToString());

                            }

                        }
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Role not defined");
                    }
                }
            }
            return View();

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword([Bind("UserName,Password,RoleId")] AccountInformation accountInformation, string confirmPass)
        {
            var user = await _context.AccountInformation.FindAsync(accountInformation.UserName);
            accountInformation.RoleId = user.RoleId;
            if (accountInformation.Password.Equals(user.Password))
            {
                ModelState.AddModelError("Password", "you can't use old password");
                return View();
            }
            if (!accountInformation.Password.Equals(confirmPass))
            {
                ModelState.AddModelError("Password", "Password mismatch");
                return View();
            }
            if (ModelState.IsValid)
            {
                user.Password = accountInformation.Password;
                _context.Update(user);
                await _context.SaveChangesAsync();
                TempData["Password"] = "Password has been reset successfully";
                return RedirectToAction("Index", "Home");


            }
            // If we got this far, something failed, redisplay form
            return View(accountInformation);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("companyid", "");
            HttpContext.Session.SetString("roleid", "");
            return RedirectToAction("Login", "AccountInformations");
        }

        // GET: AccountInformations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInformation = await _context.AccountInformation.FindAsync(id);
            if (accountInformation == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", accountInformation.RoleId);
            return View(accountInformation);
        }

        // POST: AccountInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Password,RoleId")] AccountInformation accountInformation)
        {
            if (id != accountInformation.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountInformationExists(accountInformation.UserName))
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
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "PermissionType", accountInformation.RoleId);
            return View(accountInformation);
        }

        // GET: AccountInformations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountInformation = await _context.AccountInformation
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (accountInformation == null)
            {
                return NotFound();
            }

            return View(accountInformation);
        }

        // POST: AccountInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountInformation = await _context.AccountInformation.FindAsync(id);
            _context.AccountInformation.Remove(accountInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountInformationExists(string id)
        {
            return _context.AccountInformation.Any(e => e.UserName == id);
        }
    }
}
