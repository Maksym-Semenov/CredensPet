using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IService<UserDTO> _serviceUser;
        private readonly IService<BranchDTO> _serviceBranch;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;
        private readonly IMapper _mapperBranchDTOToBranchModel;

        public UsersController(IService<UserDTO> serviceUser, 
                               IService<BranchDTO> serviceBranch, 
                               IService<ContactUserDTO> serviceContactUser)
        {
            _serviceUser = serviceUser;
            _serviceBranch = serviceBranch;
            _mapperToView = GenericMapperConfiguration<UserDTO, UserViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<UserViewModel, UserDTO>.MapTo();
            _mapperBranchDTOToBranchModel = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
        }

        // GET: Users
        public IActionResult Index()
        {
            ViewBag.BranchesNames = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");
            var item = _mapperToView.ProjectTo<UserViewModel>(_serviceUser.FindAll().AsNoTracking());
            return item != null ?
                        View(item) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
            return item != null ?
                          View(item) :
                          Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: Users
        public IActionResult Index2()
        {
            UserBranchViewModel userBranchView = new UserBranchViewModel();
            userBranchView.BranchesUsers =_mapperBranchDTOToBranchModel.ProjectTo<BranchViewModel>(_serviceBranch.FindAll());
            userBranchView.UsersBranches = _mapperToView.ProjectTo<UserViewModel>(_serviceUser.FindAll());
         
             return userBranchView != null ?
                        View(userBranchView) :
                        Problem("Entity set 'CredensContext.Users'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.BranceshNames = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");
            var item =  _mapperToView.Map<UserViewModel>(await _serviceUser.FindAll()
                .FirstOrDefaultAsync(x => x.UserId  == id));
            return View(item);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.BranchName = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchName, BranchId, FirstName, MiddleName, LastName, " +
                                                                  "UserRoleId, RoleId, UserCount, ManagerId, CustomerId, " +
                                                                  "MediatorId, MakerId, Created, LastUpdated")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceUser.AddAsync(_mapperToDTO.Map<UserDTO>(userViewModel));
                await _serviceUser.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/CreateFromBranch
        public IActionResult CreateFromBranch(int id)
        {
            ViewBag.BranchId = id;

            return View();
        }

        // POST: Users/CreateFromBranch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromBranch( [Bind("BranchId, FirstName, MiddleName, LastName, " +
                                                                            "UserRoleId, RoleId, UserCount, ManagerId, CustomerId, " +
                                                                            "MediatorId, MakerId, Created, LastUpdated")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceUser.AddAsync(_mapperToDTO.Map<UserDTO>(userViewModel));
                await _serviceUser.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Users/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.UserId = id;
            ViewBag.BranchesNames = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");

            var item = _mapperToView.Map<UserViewModel>( await _serviceUser.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Users/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,[Bind("UserId, BranchId, FirstName, MiddleName, LastName, " +
                                                                           "UserRoleId, RoleId, UserCount,ManagerId, CustomerId, " +
                                                                           "MediatorId, MakerId, Created, LastUpdated")] UserViewModel userViewModel)
        {
            if (id != userViewModel.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceUser.UpdateAsync(_mapperToDTO.Map<UserDTO>(userViewModel));
                await _serviceUser.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<UserViewModel>(await _serviceUser.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));
            if (id == null || _serviceUser == null || item == null)
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
            if (_serviceUser == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<UserDTO>(await _serviceUser.FindAll()
                .FirstOrDefaultAsync(x => x.UserId == id));
            if (item != null)
            {
                await _serviceUser.DeleteAsync(item);
            }

            await _serviceUser.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
