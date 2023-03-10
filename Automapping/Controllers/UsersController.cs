using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IService<UserDTO> _service;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public UsersController(IService<UserDTO> service)
        {
            _service = service;
            _mapperToView = GenericMapperConfiguration<UserDTO, UserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<UserViewModel, UserDTO>.MapTo();
        }

        // GET: Users
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<UserViewModel>(_service.FindAll().AsNoTracking());
              return item != null ? 
                          View( item) :
                          Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item =  _mapperToView.Map<UserViewModel>(await _service.FindAll()
                .FirstOrDefaultAsync(x => x.UserId  == id));
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
        public async Task<IActionResult> Create([Bind("UserId,FirstName,MiddleName,LastName,UserRoleId")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapperToDTO.Map<UserDTO>(userViewModel));
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<UserViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("UserId,FirstName,MiddleName,LastName,UserRoleId")] UserViewModel userViewModel)
        {
            if (id != userViewModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapperToDTO.Map<UserDTO>(userViewModel));
                await _service.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<UserViewModel>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));
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
            var item = _mapperToDTO.Map<UserDTO>(_service.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));
            if (item != null)
            {
                await _service.DeleteAsync(item);
            }

            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
