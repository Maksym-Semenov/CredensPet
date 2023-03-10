using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CredensPet.Infrastructure.DTO;
using CredensPet.Infrastructure;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactUsersController : Controller
    {
        private readonly IService<ContactUserDTO> _service;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ContactUsersController(IService<ContactUserDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<ContactUserDTO, ContactUserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactUserViewModel, ContactUserDTO>.MapTo();
        }

        // GET: Users
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ContactUserViewModel>(_service.FindAll().AsNoTracking());
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            return View(item);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactUserId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactUserViewModel contactUserViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Users/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind("ContactUserId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactUserViewModel contactUserViewModel)
        {
            if (id != contactUserViewModel.ContactUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _service.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            if (id == null || _service == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<ContactUserDTO>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            if (item != null)
            {
                await _service.DeleteAsync(item);
            }

            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
