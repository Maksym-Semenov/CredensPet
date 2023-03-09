using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IService<BranchDTO> _service;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDetails;
        public BranchesController(IService<BranchDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
            _mapperToDetails = GenericMapperConfiguration<BranchDTO, BranchDetailsViewModel>.MapTo();
        }

        // GET: Branches
        public IActionResult Index()
        {
            var branch = _mapperToView.ProjectTo<BranchViewModel>(_service.FindAll());
            return branch != null ?
                        View(branch) :
                        Problem("Entity set 'CredensTestContext.Branches'  is null.");
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var branchDTO = _mapperToDetails.Map<BranchDetailsViewModel>
                        (await _service.FindAll().FirstOrDefaultAsync(x => x.BranchId == id));
                    return View(branchDTO);
                }
            }
            catch
            {
                Console.WriteLine("What's going wrong...");
            }
            finally
            {
                RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Phone, IsOpen")] BranchDTO branchDTO)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(branchDTO);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchDTO);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var branchDTO = _mapperToDetails.Map<BranchDTO>(await _service.FindAll().FirstOrDefaultAsync(x => x.BranchId == id));

            if (branchDTO == null)
            {
                return NotFound();
            }
            return View(branchDTO);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId, Name, Phone, IsOpen")] BranchDTO branchDTO)
        {
            if (id != branchDTO.BranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(branchDTO);
                await _service.SaveChangesAsync();
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
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var branchDTO = _service.FindAll().FirstOrDefault(x => x.BranchId == id);
            return View(branchDTO);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'CredensTestContext.Branches'  is null.");
            }
            var branchDTO = _service.FindAll().FirstOrDefault(x => x.BranchId == id);
            if (branchDTO != null)
            {
                await _service.DeleteAsync(branchDTO);
            }

            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //private bool BranchExists(int id)
        //{
        //    return (_service.Any(e => e.BranchId == id)).GetValueOrDefault();
        //}
    }
}
