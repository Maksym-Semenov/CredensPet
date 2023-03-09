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
        private readonly IMapper _mapperToEditView;
        private readonly IMapper _mapperToDetails;
        private readonly IMapper _mapperToDTO;
        public BranchesController(IService<BranchDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<BranchViewModel, BranchDTO>.MapTo();
        }

        // GET: Branches
        public IActionResult Index()
        {
            var branch = _mapperToView.ProjectTo<BranchViewModel>(_service.FindAll().AsNoTracking());
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
                    var item = _mapperToView.Map<BranchViewModel>
                        (await _service.FindAll().FirstOrDefaultAsync(x => x.BranchId == id));
                    return View(item);
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
        public async Task<IActionResult> Create([Bind("Name, Phone, IsOpen")] BranchViewModel branchViewModel)
        {
            if (ModelState.IsValid)
            {
                var item = _mapperToDTO.Map<BranchDTO>(branchViewModel);
                await _service.AddAsync(item);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var item = _mapperToView.Map<BranchViewModel>(await _service.FindAll().FirstOrDefaultAsync(x => x.BranchId == id));

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId, Name, Phone, IsOpen")] BranchViewModel branchViewModel)
        {
            //var item = _mapperToDTO.Map<BranchDTO>(_service.FindAll().FirstOrDefaultAsync(x => x.BranchId == id));
            if (id != branchViewModel.BranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var item = _mapperToDTO.Map<BranchDTO>(branchViewModel);
                await _service.UpdateAsync(item);
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
            var item = _mapperToView.Map<BranchViewModel>(_service.FindAll().FirstOrDefault(x => x.BranchId == id));
            return View(item);
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
            var item = _mapperToDTO.Map<BranchDTO>(_service.FindAll().FirstOrDefault(x => x.BranchId == id));
            if (item != null)
            {
                await _service.DeleteAsync(item);
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
