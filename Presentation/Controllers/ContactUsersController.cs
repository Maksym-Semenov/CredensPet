using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CredensPet.Infrastructure.DTO;
using CredensPet.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactUsersController : Controller
    {
        private readonly IService<ContactUserDTO> _serviceContactUser;
        private readonly IService<UserDTO> _serviceUser;
        private readonly IMapper _mapperToContactUserView;
        private readonly IMapper _mapperToUserView;
        private readonly IMapper _mapperToDTO;

        public ContactUsersController(IService<ContactUserDTO> serviceContactUser,
                                      IService<UserDTO> serviceUser)
        {
            _serviceContactUser = serviceContactUser;
            _serviceUser = serviceUser;
            _mapperToContactUserView = GenericMapperConfiguration<ContactUserDTO, ContactUserViewModel>.MapTo();
            _mapperToUserView = GenericMapperConfiguration<UserDTO, UserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactUserViewModel, ContactUserDTO>.MapTo();
        }

        // GET: ContactUsers
        public IActionResult Index()
        {
            var item = new ContactUserWithUserViewModel();
            item.ListContactUserProperties = _mapperToContactUserView.ProjectTo<ContactUserViewModel>
                (_serviceContactUser.FindAll().AsNoTracking());
            item.ListUserProperties = _mapperToUserView.ProjectTo<UserViewModel>
                (_serviceUser.FindAll().AsNoTracking());
                
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: ContactUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var item = _mapperToContactUserView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            return View(item);
        }

        // GET: ContactUsers/CreateFromUser

        public async Task<IActionResult> CreateFromUser(Guid? id)
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
        public async Task<IActionResult> Update(Guid? id)
        {
            var item = _mapperToContactUserView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ContactUsers/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid? id, [Bind("UserId, ContactUserId, PhoneMain, Phone2, Email, " +
                                                                "Country, City, ResidentialComplex, " +
                                                                "TypeStreet, Street, BuildingNumber, Litera, " +
                                                                "BuildingPart, Apt, Floor, Created, LastUpdated")] ContactUserViewModel contactUserViewModel)
        {
            if (id != contactUserViewModel.Id)
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            var item = _mapperToContactUserView.Map<ContactUserViewModel>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (id == null || _serviceContactUser == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ContactUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_serviceContactUser == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<ContactUserDTO>(await _serviceContactUser.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (item != null)
            {
                await _serviceContactUser.DeleteAsync(item);
            }

            await _serviceContactUser.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
