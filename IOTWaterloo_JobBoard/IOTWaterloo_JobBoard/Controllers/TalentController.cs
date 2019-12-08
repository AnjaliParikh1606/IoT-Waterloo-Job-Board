using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IOTWaterloo_JobBoard.Models;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IOTWaterloo_JobBoard.ViewModel;
using System.Net.Mail;
using System.Net;

namespace IOTWaterloo_JobBoard.Controllers
{
    public class TalentController : Controller
    {
        private readonly JobBoardContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        /// code by: Rajvi Rami
        /// description: constructor 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="environment"></param>
        /// //JobDetailController
        public TalentController(JobBoardContext context, IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
            _context = context;
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// description: index view
        /// </summary>
        /// <returns></returns>
        // GET: JobDetail
        public async Task<IActionResult> Index()
        {
            var jobBoardContext = _context.JobDetails.Include(j => j.Compnay);
            return View(await jobBoardContext.ToListAsync());
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// description: get details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

            var model = new CandidateViewModel()
            {
                jobDetails = jobDetails,

            };

            return View(model);
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// description: create call
        /// </summary>
        /// <returns></returns>
        // GET: JobDetail/Create
        public IActionResult Create()
        {
            ViewData["CompnayId"] = new SelectList(_context.CompanyDetails, "CompanyId", "CompanyId");
            return View();
        }


        /// <summary>
        /// code by: Rajvi Rami
        /// descripiton: post call for creating record
        /// </summary>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
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


        /// <summary>
        /// code by: Rajvi Rami
        /// descripition: edit record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// code by: Rajvi Rami
        ///  description: Save edit record
        /// </summary>
        /// <param name="id">id of the record</param>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
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

        /// <summary>
        /// code by: Rajvi Rami
        /// descripiton: delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// code by: Rajvi Rami
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// code by: Rajvi Rami
        /// descripiton: job search 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet, ActionName("JobSearch")]
        public async Task<IActionResult> JobSearch(string query)
        {


            var test = from s in _context.JobDetails
                       where EF.Functions.Like(s.JobTitle, "%" + query + "%")
                       select s;


            return Json(test);
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// descripiton: job search result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, ActionName("JobSearchResult")]
        public PartialViewResult JobSearchResult(/*JobDetails request*/ JobViewModel request)
        {

            var jobDetails = from s in _context.JobDetails.Include(x => x.Compnay)
                             select s;

            if (request.JobTitle != null)
            {
                //var _val = request.JobTitle.Split(' ');
                jobDetails = from s in _context.JobDetails.Include(x => x.Compnay)
                             where EF.Functions.Like(s.JobTitle, "%" + request.JobTitle.ToLower() + "%")
                             select s;

                //for (int i = 1; i < _val.Length; i++)
                //{
                //    jobDetails = from s in jobDetails
                //                 where EF.Functions.Like(s.JobTitle, "%" + _val[i].ToLower() + "%")
                //                 select s;
                //}

            }

            if (request.Location != null)
            {
                //var _val = request.JobTitle.Split(' ');
                jobDetails = from s in jobDetails
                             where EF.Functions.Like(s.Location.ToLower(), "%" + request.Location.ToLower() + "%")
                             select s;

                //for (int i = 1; i < _val.Length; i++)
                //{
                //    jobDetails = from s in jobDetails
                //                 where EF.Functions.Like(s.Location.ToLower(), "%" + _val[i].ToLower() + "%")
                //                 select s;
                //}

            }


            if (request.Jobtype != null)
            {
                var _job = request.Jobtype?.Split(',');
                jobDetails = from s in jobDetails
                             where _job.Contains(s.Jobtype.ToLower())
                             select s;
            }

            if (request.JobDate != null)
            {
                // this is suppose to be sorting, right.?
                // it will  not work out.
                // we'll do filter

                jobDetails = from s in jobDetails
                             where s.JobPostDate >= request.JobDate && s.JobPostDate <= DateTime.UtcNow
                             select s;
            }

            return PartialView("_JobDetails", jobDetails);
        }


        /// <summary>
        /// code by: Rajvi Rami
        /// description: upload document
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(/*CandidateDetails request*/ CandidateViewModel request)
        {

            #region MyRegion
            //        // do other validations on your model as needed
            //        if (request.Resume.FilePath != null)
            //        {
            //            var uniqueFileName = GetUniqueFileName(request.Resume.FilePath);
            //            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            //            var filePath = Path.Combine(uploads, uniqueFileName);
            //            request.resu.CopyTo(new FileStream(filePath, FileMode.Create));

            //            //to do : Save uniqueFileName  to your db table   
            //        }
            //        // to do  : Return something
            //        return RedirectToAction("Index", "Home");
            //    }
            //    private string GetUniqueFileName(string fileName)
            //    {
            //        fileName = Path.GetFileName(fileName);
            //        return Path.GetFileNameWithoutExtension(fileName)
            //                  + "_"
            //                  + Guid.NewGuid().ToString().Substring(0, 4)
            //                  + Path.GetExtension(fileName);
            //    }
            //}
            #endregion

            if (ModelState.IsValid)
            {
                //_context.Add(request);
                //await _context.SaveChangesAsync();
                ViewData["success"] = true;
                TempData["success"] = true;

                var Upload = request.Document;

                var uniqueFileName = GetUniqueFileName(Upload.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);

                //var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                try
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        var resume = new Resume()
                        {
                            FilePath = filePath
                        };
                        _context.Resume.Add(resume);

                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Resume ON;");
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Resume OFF;");
                        transaction.Commit();

                        if (!string.IsNullOrWhiteSpace(request.URL))
                        {
                            var link = new LinkedInProfiles()
                            {
                                ProfilrUrl = request.URL
                            };
                            _context.LinkedInProfiles.Add(link);
                        }
                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT LinkedInProfiles ON;");
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT LinkedInProfiles OFF;");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var companyName = _context.CompanyDetails
                    .Where(s => s.CompanyId == request.jobDetails.Compnay.CompanyId)
                    .Select(s => s.CompanyName).FirstOrDefault();

                #region Old code
                //MailMessage msg = new MailMessage("aashu.rajvi737@gmail.com", "testwaterloo@mailinator.com"); // enter from email and to email

                //msg.Body = "<html><head><head><body>you got an email</body></html>"; //enter body here
                //msg.Subject = "strSubject"; // enter subject line here

                //msg.IsBodyHtml = true;
                //Attachment att = new Attachment(filePath);
                //msg.Attachments.Add(att);

                //SmtpClient cli = new SmtpClient("111.111.111.111", 25);
                //cli.Credentials = new NetworkCredential("nnnnnnn", "yyyyyy");
                //cli.Send(msg);
                //msg.Dispose();
                #endregion

                #region new code email

                //send email
                using (MailMessage mm = new MailMessage("iotwaterloojobboard@gmail.com", "anjalid166@gmail.com")) // fromId, ToId
                {
                    mm.Subject = "IOT Waterloo Candidate Detail (Job Request)";
                    mm.Body = request.FirstName + " " + request.LastName + " requesting for a job from " +
                        companyName + "and here are the detials.";

                    Attachment attachment = new Attachment(Upload.OpenReadStream(), uniqueFileName);

                    mm.Attachments.Add(attachment);
                    mm.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential netwoekCred = new NetworkCredential("iotwaterloojobboard@gmail.com", "iot123456$");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = netwoekCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }

                #endregion

            }

            //return Ok(new { Status = "Success" }); JobDetail/Details/8
            return RedirectToAction("Details", "Talent", new { id = request.jobDetails.JobId });
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// descripition: method for getting uniq name 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        /// <summary>
        /// code by: Rajvi Rami
        /// descripition: method for checking if job already exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool JobDetailsExists(int id)
        {
            return _context.JobDetails.Any(e => e.JobId == id);
        }

    }
}