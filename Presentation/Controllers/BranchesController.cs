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
        private readonly IService<BranchDTO> _serviceBranch;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public BranchesController(IService<BranchDTO> serviceBranch)
        {
            _serviceBranch = serviceBranch;
            _mapperToView = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<BranchViewModel, BranchDTO>.MapTo();
        }

        // GET: Branches
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<BranchViewModel>(_serviceBranch.FindAll().AsNoTracking());
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensTestContext.Branches'  is null.");
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<BranchViewModel>(await _serviceBranch.FindAll()
                .FirstOrDefaultAsync(x => x.BranchId == id));
            return View(item);
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
                            "BranchName, Phone, IsOpen, Created, LastUpdated")] BranchViewModel branchViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceBranch.AddAsync(_mapperToDTO.Map<BranchDTO>(branchViewModel));
                await _serviceBranch.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Branches/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<BranchViewModel>(await _serviceBranch.FindAll()
                .FirstOrDefaultAsync(x => x.BranchId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Branches/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind(
                            "BranchId, BranchName, Phone, IsOpen, Created, LastUpdated")] BranchViewModel branchViewModel)
        {
            if (id != branchViewModel.BranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceBranch.UpdateAsync(_mapperToDTO.Map<BranchDTO>(branchViewModel));
                await _serviceBranch.SaveChangesAsync();
            }
           
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<BranchViewModel>(await _serviceBranch.FindAll()
                .FirstOrDefaultAsync(x => x.BranchId == id));
            if (id == null || _serviceBranch == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_serviceBranch == null)
            {
                return Problem("Entity set 'CredensTestContext.Branches'  is null.");
            }
            var item = _mapperToDTO.Map<BranchDTO>(await _serviceBranch.FindAll()
                .FirstOrDefaultAsync(x => x.BranchId == id));
            if (item != null)
            {
                await _serviceBranch.DeleteAsync(item);
            }

            await _serviceBranch.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
