using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreDbFirst.Models;

namespace EfCoreDbFirst.Controllers
{
    public class StudentTbsController : Controller
    {
        private readonly StudentEntityDbFirstContext _context;

        public StudentTbsController(StudentEntityDbFirstContext context)
        {
            _context = context;
        }

        // GET: StudentTbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentTb.ToListAsync());
        }

        // GET: StudentTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // GET: StudentTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,Standard")] StudentTb studentTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTb);
        }

        // GET: StudentTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb.FindAsync(id);
            if (studentTb == null)
            {
                return NotFound();
            }
            return View(studentTb);
        }

        // POST: StudentTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Age,Standard")] StudentTb studentTb)
        {
            if (id != studentTb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTbExists(studentTb.Id))
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
            return View(studentTb);
        }

        // GET: StudentTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // POST: StudentTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTb = await _context.StudentTb.FindAsync(id);
            _context.StudentTb.Remove(studentTb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTbExists(int id)
        {
            return _context.StudentTb.Any(e => e.Id == id);
        }
    }
}
