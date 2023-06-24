// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using TesisPadel.Data;
// using TesisPadel.Models;

// namespace TesisPadel.ClubControllers{
//     public class NoticiaController : Controller
//     {
//         private readonly TesisPadelDbContext _context;

//         public NoticiaController(TesisPadelDbContext context)
//         {
//             _context = context;
//         }

//         // GET: Notica
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Noticia.ToListAsync());
//         }

//         // GET: Noticia/Details/5
//         public async Task<IActionResult> Details(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var Noticia = await _context.Noticia
//                 .FirstOrDefaultAsync(m => m.NoticiaId == id);
//             if (Noticia == null)
//             {
//                 return NotFound();
//             }

//             return View(Noticia);
//         }

//         // GET: Noticia/Create
//         public IActionResult Create()
//         {
//             return View();
//         }
//         // POST: Noticia/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("NoticiaId,Eliminado")] Noticia Noticia)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(Noticia);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(Noticia);
//         }

//         // GET: Noticia/Edit/5
//         public async Task<IActionResult> Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var Noticia = await _context.Noticia.FindAsync(id);
//             if (Noticia == null)
//             {
//                 return NotFound();
//             }
//             return View(Noticia);
//         }

//         // POST: Noticia/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(int id, [Bind("NoticiaId,Nombre")] Noticia Noticia)
//         {
//             if (id != Noticia.NoticiaId)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(Noticia);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!ClubExists(Noticia.NoticiaId)
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(Noticia);
//         }

//         // GET: noticia/Delete/5
//         public async Task<IActionResult> Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var Noticia = await _context.Noticia
//                 .FirstOrDefaultAsync(m => m.NoticiaId == id);
//             if (Noticia == null)
//             {
//                 return NotFound();
//             }

//             return View(Noticia);
//         }

//         // POST: Noticia/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var Noticia = await _context.Noticia.FindAsync(id);
//             _context.Noticia.Remove(Noticia);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         private bool NoticiaExists(int id)
//         {
//             return _context.Noticia.Any(e => e.NoticiaId == id);
//         }

//     }
// }