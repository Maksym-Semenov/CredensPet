using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IService<BranchDTO> _service;
        private readonly IMapper _mapper;
        public BranchesController(IService<BranchDTO> service)
        {
            _service = service;
            _mapper = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
        }

        // GET: Branches
        public IActionResult Index()
        {
            var branch = _mapper.Map<IEnumerable<BranchViewModel>>(_service.GetAll());
            return branch != null ?
                        View(branch) :
                        Problem("Entity set 'CredensTestContext.Branches'  is null.");
        }

        //// GET: Branches/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Branches == null)
        //    {
        //        return NotFound();
        //    }

        //    var branch = await _context.Branches
        //        .FirstOrDefaultAsync(m => m.BranchId == id);
        //    if (branch == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(branch);
        //}

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BranchId,Name")] BranchDTO branchDTO)
        {
            if (ModelState.IsValid)
            {
                _service.Add(branchDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(branchDTO);
        }

        //// GET: Branches/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Branches == null)
        //    {
        //        return NotFound();
        //    }

        //    var branch = await _context.Branches.FindAsync(id);
        //    if (branch == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(branch);
        //}

        //// POST: Branches/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BranchId,Name,Phone,IsOpen")] Branch branch)
        //{
        //    if (id != branch.BranchId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(branch);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BranchExists(branch.BranchId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(branch);
        //}

        //// GET: Branches/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Branches == null)
        //    {
        //        return NotFound();
        //    }

        //    var branch = await _context.Branches
        //        .FirstOrDefaultAsync(m => m.BranchId == id);
        //    if (branch == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(branch);
        //}

        //// POST: Branches/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Branches == null)
        //    {
        //        return Problem("Entity set 'CredensTestContext.Branches'  is null.");
        //    }
        //    var branch = await _context.Branches.FindAsync(id);
        //    if (branch != null)
        //    {
        //        _context.Branches.Remove(branch);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BranchExists(int id)
        //{
        //  return (_context.Branches?.Any(e => e.BranchId == id)).GetValueOrDefault();
        //}
    }
}
