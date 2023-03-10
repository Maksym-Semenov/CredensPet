using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IService<ProjectDTO> _service;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ProjectsController(IService<ProjectDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<ProjectDTO, ProjectViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ProjectViewModel, ProjectDTO>.MapTo();
        }

        // GET: Projects
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ProjectViewModel>(_service.FindAll().AsNoTracking());
            return item != null ? 
                View(item) : 
                Problem("Entity set 'CredensTestContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ProjectViewModel>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            return View(item);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,OrderValue,OrderMonth,OrderYear,OrderName,Price,City")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapperToDTO.Map<ProjectDTO>(projectViewModel));
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<ProjectViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //POST: Projects/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind("ProjectId,OrderValue,OrderMonth,OrderYear,CustomerId,OrderName,Price,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Litera,BuildingPart,Apartment,Floor,ManagerId,MakerId,BranchId")] ProjectViewModel projectViewModel)
        {
            if (id != projectViewModel.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapperToDTO.Map<ProjectDTO>(projectViewModel));
                await _service.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<ProjectViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            if (id == null || _service == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<ProjectDTO>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            if (item != null)
            {
                await _service.DeleteAsync(item);
            }

            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
