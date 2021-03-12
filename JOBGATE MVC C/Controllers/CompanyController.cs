using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JOBGATE_MVC_C.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AccountsContext _context;
        public CompanyController(AccountsContext context)
        {

            _context = context;

        }
        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Candidate()
        {
           

            List<PostViewModel> model = new List<PostViewModel>();
           var  Resume = (from Re in _context.ResumeEPY

                          //join JobFieldEPY in _context.JobFields on Re.JobfieldId equals JobFieldEPY.Id
                     
                      // join loca in _context.Location on Re.locationId equals loca.Id

                      // join JobFieldEPY2 in _context.JobFields on Re.JobField2Id equals JobFieldEPY2.Id into newgroup
                      // from J in newgroup.DefaultIfEmpty()
                       //join Edu in _context.EducationEPY on Re.Id equals Edu.ResumeId into edugroup
                       //from g in edugroup.DefaultIfEmpty()

                       //join de in _context.DegreeEPY on g.DegreeId equals de.Id into degroup
                       //from m in degroup.DefaultIfEmpty()
                       //join Mem in _context.MembersInfoEPY on Re.MemberRegisterId equals Mem.ClientId into memgroup
                       //from mem in memgroup.DefaultIfEmpty()
                      // join gen in _context.Gender on mem.GenderId equals gen.Id into gen
                     //  from gende in gen.DefaultIfEmpty()

                     //  join Img in _context.imageFiles on mem.ClientId equals Img.ClientId into imggroup
                      // from im in imggroup.DefaultIfEmpty()
                     
                       orderby Re.Update_at
                       group Re.ResumeName by new
                       {
                           MemberRegisterId = Re.MemberRegisterId
                          // Id = Re.Id,
                           //FirstName = mem.FirstName,
                          // LastName = mem.LastName,
                           //ResumeName = Re.ResumeName,
                           //Jobfield = JobFieldEPY.JobField_Eng,
                           //Jobfield2 = (J.JobField_Eng == null ? "" : " , " + J.JobField_Eng.ToString()),
                           //ExpectedSalary = Re.ExpectedSalary,
                           //Location = loca.Province_Eng,
                           //Show_open = Re.Show_open,
                           //Img = (im.ImageName == null ? "" : im.ImageName.ToString()),
                           //Dateup = Re.Update_at,
                           //birthday = mem.Birthday,
                           //Gender = (gende.GenderName == null ? "" : gende.GenderName.ToString())
                       } into gr
                       // where Re.MemberRegisterId == Id
                       select new
                       {
                           MemberRegisterId = gr.Key.MemberRegisterId
                           //Id = gr.Key,
                           //ShoolNames = gr.ToList(),
                           //FirstName = gr.Key.FirstName,
                           //LastName = gr.Key.LastName,
                           //ResumeName = gr.Key.ResumeName,
                           //Jobfield = gr.Key.Jobfield,
                           //Jobfield2 = gr.Key.Jobfield2,
                           //ExpectedSalary = gr.Key.ExpectedSalary,
                           //Location = gr.Key.Location,
                           //Show_open = gr.Key.Show_open,
                           //Img = gr.Key.Img,
                           //Dateup = gr.Key.Dateup,
                           //birthday = gr.Key.birthday,
                           //Gender = gr.Key.Gender



                       }).ToList();

            foreach (var item in Resume) //retrieve each item and assign to model
            {

              //  DateTime dob = item.birthday;
                DateTime Today = DateTime.Now;
               // TimeSpan ts = Today - dob;
              //  DateTime Age = DateTime.MinValue + ts;

                //int Years = Age.Year - 1;
                //int Months = Age.Month - 1;
                //int Days = Age.Day - 1;
                model.Add(new PostViewModel()
                {
                    //ResumeName = item.ResumeName,
                    //Jobfield = item.Jobfield,
                    //Jobfield2 = item.Jobfield2,
                    //ExpectedSalary = item.ExpectedSalary,
                    //Location = item.Location,
                    //Show_open = item.Show_open,
                    //Id = item.Id,
                   // FirstName = item.FirstName,
                   // LastName = item.LastName,
                    //Img = item.Img,
                    //Updatetime = item.Dateup,
                    //Genders = item.Gender,
                   // birthday = Years
                   FirstName  = item.MemberRegisterId

                });
            }
            var job = _context.JobFieldEPY
                  .AsEnumerable()
                   .OrderBy(i => i.JobField_Eng)
                  .GroupBy(
                  i => i.JobField_Eng
                 )
                  .Select(x => x.First())
                   .ToList();

            var pro = _context.Location
                  .AsEnumerable()
                  .OrderBy(i => i.Province_Eng)
                  .GroupBy(
                  i => i.Province_Eng
                 ).Select(x => x.First())
                   .ToList();

            var degree = _context.Degrees
                 .AsEnumerable()
                 .OrderBy(i => i.Degree_Eng)
                 .Select(i => new { i.Id, i.Degree_Eng })
                  .ToList();

            ViewBag.listdegree = new SelectList(degree, "Id", "Degree_Eng");
            ViewBag.listjob = new SelectList(job, "Id", "JobField_Eng");
            ViewBag.listprovince = new SelectList(pro, "Id", "Province_Eng");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SearchJob(string searchString)
        {
            var movies = from m in _context.MembersInfoEPY
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.FirstName.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        public IActionResult MyCompany()
        {
            return View();
        }
    }
}
