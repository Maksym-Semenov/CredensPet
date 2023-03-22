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
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ContactUsersController(IService<ContactUserDTO> serviceContactUser)
        {
            _serviceContactUser = serviceContactUser;
            _mapperToView = GenericMapperConfiguration<ContactUserDTO, ContactUserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactUserViewModel, ContactUserDTO>.MapTo();
        }

        // GET: ContactUsers
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ContactUserViewModel>(_serviceContactUser.FindAll().AsNoTracking());
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: ContactUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.ContactUserId == id));
            return View(item);
        }

        // GET: ContactUsers/CreateFromUser

        public async Task<IActionResult> CreateFromUser(int? id)
        {
            ViewBag.UserId = id;
            return View();
        }

        // POST: ContactUsers/CreateFromUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromUser([Bind("UserId, PhoneMain, Phone2, Email, " +
                                                                          "Country, City, ResidentialComplex, " +
                                                                          "TypeStreet, Street, BuildingNumber, Litera, " +
                                                                          "BuildingPart, Apt, Floor, Created, LastUpdated")] ContactUserViewModel contactUserViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceContactUser.AddAsync(_mapperToDTO.Map<ContactUserDTO>(contactUserViewModel));
                await _serviceContactUser.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Users");
        }

        // GET: ContactUsers/Update/5
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

        // POST: ContactUsers/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind("UserId, ContactUserId, PhoneMain, Phone2, Email, " +
                                                               "Country, City, ResidentialComplex, " +
                                                               "TypeStreet, Street, BuildingNumber, Litera, " +
                                                               "BuildingPart, Apt, Floor, Created, LastUpdated")] ContactUserViewModel contactUserViewModel)
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

        // GET: ContactUsers/Delete/5
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

        // POST: ContactUsers/Delete/5
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
