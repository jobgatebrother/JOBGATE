//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using JOBGATE_MVC_C.Models;

//namespace JOBGATE_MVC_C.Controllers
//{
//    public class RegisterEPYController : Controller
//    {
//        private readonly AccountsContext _context;

//        public RegisterEPYController(AccountsContext context)
//        {
//            _context = context;
//        }

//        // GET: RegisterEPY
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Register.ToListAsync());
//        }

//        // GET: RegisterEPY/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var register_EPYModel = await _context.Register
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (register_EPYModel == null)
//            {
//                return NotFound();
//            }

//            return View(register_EPYModel);
//        }

//        // GET: RegisterEPY/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: RegisterEPY/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Email,Password,ConfirmEmail")] Register_EPYModel register_EPYModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(register_EPYModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(register_EPYModel);
//        }

//        // GET: RegisterEPY/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var register_EPYModel = await _context.Register.FindAsync(id);
//            if (register_EPYModel == null)
//            {
//                return NotFound();
//            }
//            return View(register_EPYModel);
//        }

//        // POST: RegisterEPY/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Password,ConfirmEmail")] Register_EPYModel register_EPYModel)
//        {
//            if (id != register_EPYModel.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(register_EPYModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!Register_EPYModelExists(register_EPYModel.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(register_EPYModel);
//        }

//        // GET: RegisterEPY/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var register_EPYModel = await _context.Register
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (register_EPYModel == null)
//            {
//                return NotFound();
//            }

//            return View(register_EPYModel);
//        }

//        // POST: RegisterEPY/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var register_EPYModel = await _context.Register.FindAsync(id);
//            _context.Register.Remove(register_EPYModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool Register_EPYModelExists(int id)
//        {
//            return _context.Register.Any(e => e.ID == id);
//        }
//    }
//}
