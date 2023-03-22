using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CredensPet.Infrastructure.DTO;
using CredensPet.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactUsersController : Controller
    {
        private readonly IService<ContactUserDTO> _serviceContactUser;
        private readonly IService<UserDTO> _serviceUser;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ContactUsersController(IService<ContactUserDTO> serviceContactUser, IService<UserDTO> serviceUser)
        {
            _serviceContactUser = serviceContactUser;
            _serviceUser = serviceUser;
            _mapperToView = GenericMapperConfiguration<ContactUserDTO, ContactUserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactUserViewModel, ContactUserDTO>.MapTo();
        }

        // GET: Users
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ContactUserViewModel>(_serviceContactUser.FindAll().AsNoTracking());
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            return View(item);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.UserId = new SelectList(_serviceUser.FindAll().Select(x => x.UserId));
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactUserViewModel contactUserViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceContactUser.AddAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _serviceContactUser.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> CreateFromUser(int? id)
        {
            ViewBag.UserId = new SelectList(_serviceUser.FindAll().Select(x => x.UserId));
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromUser([Bind("UserId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactUserViewModel contactUserViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceContactUser.AddAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _serviceContactUser.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Users");
        }

        // GET: Users/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
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
        public async Task<IActionResult> Update(int? id, [Bind("ContactUserId, UserId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactUserViewModel contactUserViewModel)
        {
            if (id != contactUserViewModel.ContactUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceContactUser.UpdateAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _serviceContactUser.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            if (id == null || _serviceContactUser == null || item == null)
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
            if (_serviceContactUser == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<ContactUserDTO>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            if (item != null)
            {
                await _serviceContactUser.DeleteAsync(item);
            }

            await _serviceContactUser.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
