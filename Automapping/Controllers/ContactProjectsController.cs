using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactProjectsController : Controller
    {
        private readonly IService<ContactProjectDTO> _service;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ContactProjectsController(IService<ContactProjectDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<ContactProjectDTO, ContactProjectViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactProjectViewModel, ContactProjectDTO>.MapTo();
        }

        // GET: ContactProjects
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ContactProjectViewModel>(_service.FindAll().AsNoTracking());
              return item != null ? 
                          View(item) :
                          Problem("Entity set 'CredensTestContext.Contacts'  is null.");
        }

        // GET: ContactProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            return View(item);
        }

        // GET: ContactProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactProjectId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactProjectViewModel contactProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapperToDTO.Map<ContactProjectDTO>(contactProjectViewModel));
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactProjects/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ContactProjects/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind("ContactProjectId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactProjectViewModel contactProjectViewModel)
        {
            if (id != contactProjectViewModel.ContactProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    await _service.UpdateAsync(_mapperToDTO.Map<ContactProjectDTO>(contactProjectViewModel));
                    await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: ContactProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (id == null || _service == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ContactProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'CredensTestContext.Contacts'  is null.");
            }
            var item = _mapperToDTO.Map<ContactProjectDTO>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (item != null)
            {
                await _service.DeleteAsync(item);
            }

            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
