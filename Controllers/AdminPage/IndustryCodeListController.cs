using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JOBGATE.Data;
using JOBGATE.Models;

namespace JOBGATE.Controllers.AdminPage
{
    public class IndustryCodeListController : Controller
    {
        private readonly JOBGATEAdminContext _context;

        public IndustryCodeListController(JOBGATEAdminContext context)
        {
            _context = context;
        }

        // GET: IndustryCodeList
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndustryCodeList.ToListAsync());
        }

        // GET: IndustryCodeList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industryCodeList = await _context.IndustryCodeList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (industryCodeList == null)
            {
                return NotFound();
            }

            return View(industryCodeList);
        }

        // GET: IndustryCodeList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndustryCodeList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,IndustryNameTH,IndustryNameEN")] IndustryCodeList industryCodeList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industryCodeList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(industryCodeList);
        }

        // GET: IndustryCodeList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industryCodeList = await _context.IndustryCodeList.FindAsync(id);
            if (industryCodeList == null)
            {
                return NotFound();
            }
            return View(industryCodeList);
        }

        // POST: IndustryCodeList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,IndustryNameTH,IndustryNameEN")] IndustryCodeList industryCodeList)
        {
            if (id != industryCodeList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industryCodeList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustryCodeListExists(industryCodeList.ID))
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
            return View(industryCodeList);
        }

        // GET: IndustryCodeList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industryCodeList = await _context.IndustryCodeList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (industryCodeList == null)
            {
                return NotFound();
            }

            return View(industryCodeList);
        }

        // POST: IndustryCodeList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var industryCodeList = await _context.IndustryCodeList.FindAsync(id);
            _context.IndustryCodeList.Remove(industryCodeList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndustryCodeListExists(int id)
        {
            return _context.IndustryCodeList.Any(e => e.ID == id);
        }
    }
}
