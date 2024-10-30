using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using ClothesMVC.Data;
using ClothesMVC.Models;

namespace ClothesMVC.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ClothesMVCContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClothesController(ClothesMVCContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Clothes
        public async Task<IActionResult> Index(string clothesType, string searchString)
        {
            if (_context.Clothes == null)
            {
                return Problem("Entity set 'ClothesMVC' is null");
            }

            // use LINQ to get list of types
            IQueryable<string> typeQuery = from c in _context.Clothes
                                           orderby c.Type
                                           select c.Type;
            var clothes = from c in _context.Clothes
                          select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clothes = clothes.Where(c => c.Name!.ToUpper().Contains(searchString.ToUpper()));
            }
            if (!string.IsNullOrEmpty(clothesType))
            {
                clothes = clothes.Where(c => c.Type == clothesType);
            }

            var clothesTypeVM = new ClothesTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Clothes = await clothes.ToListAsync()
            };

            return View(clothesTypeVM);
        }

        //[HttpPost]
        //public string Index(string searchString, bool notUsed)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //} // POST: hide the parameter in URL

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Name,Size,Brand,Condition,DateBuy,Price")] Clothes clothes, IFormFile Image)
        {
            if (Image == null)
            {
                ModelState.AddModelError("Image", "Please choose an image to upload.");
            }
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(Image.FileName);
                    var extension = Path.GetExtension(Image.FileName);
                    var uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }

                    clothes.Image = $"/images/{uniqueFileName}";
                }

                _context.Add(clothes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothes);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Name,Size,Brand,Condition,DateBuy,Price")] Clothes clothes, IFormFile Image)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(Image.FileName);
                        var extension = Path.GetExtension(Image.FileName);
                        var uniqueFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        var filePath = Path.Combine(uploads, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(fileStream);
                        }
                        if (!string.IsNullOrEmpty(clothes.Image))
                        {
                            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, clothes.Image.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        clothes.Image = $"/images/{uniqueFileName}";
                    }
                    _context.Update(clothes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.Id))
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
            return View(clothes);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes != null)
            {
                _context.Clothes.Remove(clothes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }
    }
}
