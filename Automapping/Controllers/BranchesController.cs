using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IService<BranchDTO> _service;
        private readonly IMapper _mapper1;
        private readonly IMapper _mapper2;
        private readonly IMapper _mapper3;
        public BranchesController(IService<BranchDTO> service)
        {
            _service = service;
            _mapper1 = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
            _mapper2 = GenericMapperConfiguration<BranchDTO, BranchDetailsViewModel>.MapTo();
            //_mapper3 = GenericMapperConfiguration<BranchDTO, BranchEditViewModel>.MapTo();
        }

        // GET: Branches
        public IActionResult Index()
        {
            var branch = _mapper1.Map<IEnumerable<BranchViewModel>>(_service.GetAll());
            return branch != null ?
                        View(branch) :
                        Problem("Entity set 'CredensTestContext.Branches'  is null.");
        }

        // GET: Branches/Details/5
        public IActionResult Details(int id)
        {
            var branchDTO = _mapper2.Map<BranchDetailsViewModel>(_service
                .Find(id));
            return View(branchDTO);
        }

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

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null || _service == null)
            //{
            //    return NotFound();
            //}

            var branchDTO = _mapper2.Map<BranchDTO>(_service.Find(id));
            
            //if (branch == null)
            //{
            //    return NotFound();
            //}
            return View(branchDTO);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BranchId,Name,Phone,IsOpen")] BranchDTO branchDTO)
        {
            //if (id != branchDTO.BranchId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                _service.Update(branchDTO);
                _service.SaveChanges();
            }
            
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _service.Update(branchDTO);
            //        await _S.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!BranchExists(branchDTO.BranchId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
                return RedirectToAction(nameof(Index));
                return View();
        }
         

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
        //    return (_service.Any(e => e.BranchId == id)).GetValueOrDefault();
        //}
    }
}
