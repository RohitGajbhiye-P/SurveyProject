using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurveyProject.Models;

namespace SurveyProject.Controllers
{
    public class DataController : Controller
    {
        private readonly ConnectionModel _context;

        public DataController(ConnectionModel context)
        {
            _context = context;
        }

        // GET: Data
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataModel.ToListAsync());
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return View(dataModel);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,AccountNumber,BenificiaryName,BankName,SWIFTCode,Amount")] DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataModel);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModel.FindAsync(id);
            if (dataModel == null)
            {
                return NotFound();
            }
            return View(dataModel);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,AccountNumber,BenificiaryName,BankName,SWIFTCode,Amount")] DataModel dataModel)
        {
            if (id != dataModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataModelExists(dataModel.id))
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
            return View(dataModel);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return View(dataModel);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataModel = await _context.DataModel.FindAsync(id);
            _context.DataModel.Remove(dataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataModelExists(int id)
        {
            return _context.DataModel.Any(e => e.id == id);
        }
    }
}
