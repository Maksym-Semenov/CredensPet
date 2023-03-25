using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IService<ProjectDTO> _serviceProject;
        private readonly IService<UserDTO> _serviceUser;
        private readonly IService<BranchDTO> _serviceBranch;
        private readonly IMapper _mapperToProjectView;
        private readonly IMapper _mapperToUserView;
        private readonly IMapper _mapperToBranchView;
        private readonly IMapper _mapperToDTO;

        public ProjectsController(IService<ProjectDTO> serviceProject
                                , IService<UserDTO> serviceUser
                                , IService<BranchDTO> serviceBranch)
        {
            _serviceProject = serviceProject;
            _serviceUser = serviceUser;
            _serviceBranch = serviceBranch;
            _mapperToProjectView = GenericMapperConfiguration<ProjectDTO, ProjectViewModel>.MapTo();
            _mapperToUserView = GenericMapperConfiguration<UserDTO, UserViewModel>.MapTo();
            _mapperToBranchView = GenericMapperConfiguration<BranchDTO, BranchViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ProjectViewModel, ProjectDTO>.MapTo();
            
        }

        // GET: Projects
        public IActionResult Index()
        {
            var item = new ProjectUserBranchViewModel();
            item.ListProjectProperties = _mapperToProjectView.ProjectTo<ProjectViewModel>(_serviceProject.FindAll());
            item.ListUserProperties = _mapperToUserView.ProjectTo<UserViewModel>(_serviceUser.FindAll());
            item.ListBranchProperties = _mapperToBranchView.ProjectTo<BranchViewModel>(_serviceBranch.FindAll());
            return item != null ? 
                View(item) : 
                Problem("Entity set 'CredensTestContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToProjectView.Map<ProjectViewModel>(await _serviceProject.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));

            return View(item);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewBag.UsersNames = new SelectList(_serviceUser.FindAll(), "UserId", "FirstName");
            ViewBag.BranchesNames = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");
            var a = ViewBag.Branch;

            return View();
        }

        //POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId, BranchId, OrderValue, OrderMonth, OrderYear" +
                                                      ", OrderName, Price, City,CustomerId, ManagerId, MakerId" +
                                                      ", MediatorId, Created, LastUpdated")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceProject.AddAsync(_mapperToDTO.Map<ProjectDTO>(projectViewModel));
                await _serviceProject.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/CreateFromUser
        public IActionResult CreateFromUser(int userId, int branchId)
        {
            ViewBag.UserId = userId;
            ViewBag.BranchId = branchId;
            
            return View();
        }


        //POST: Projects/CreateFromUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromUser([Bind("UserId, BranchId, OrderValue, OrderMonth, OrderYear, " +
                                                              "OrderName, Price, City,CustomerId, ManagerId, MakerId, " +
                                                              "MediatorId, Created, LastUpdated")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceProject.AddAsync(_mapperToDTO.Map<ProjectDTO>(projectViewModel));
                await _serviceProject.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/Update/5
        public async Task<IActionResult> Update(int? id)
        
        {
            ViewBag.ProjectId = id;
            ViewBag.UsersNames = new SelectList(_serviceUser.FindAll(), "UserId", "FirstName");
            ViewBag.BranchesNames = new SelectList(_serviceBranch.FindAll(), "BranchId", "BranchName");
            var item = _mapperToProjectView.Map<ProjectViewModel>(await _serviceProject.FindAll()
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
        public async Task<IActionResult> Update(int? id, [Bind("ProjectId, UserId, BranchId, OrderValue, OrderMonth, OrderYear, " +
                                                               "OrderName, Price, City,CustomerId, ManagerId, MakerId, " +
                                                               "MediatorId, Created, LastUpdated")] ProjectViewModel projectViewModel)
        {
            if (id != projectViewModel.ProjectId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                await _serviceProject.UpdateAsync(_mapperToDTO.Map<ProjectDTO>(projectViewModel));
                await _serviceProject.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToProjectView.Map<ProjectViewModel>(await _serviceProject.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            if (id == null || _serviceProject == null || item == null)
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
            if (_serviceProject == null)
            {
                return Problem("Entity set 'CredensTestContext.Projects'  is null.");
            }
            var item = _mapperToDTO.Map<ProjectDTO>(await _serviceProject.FindAll()
                .FirstOrDefaultAsync(x => x.ProjectId == id));
            if (item != null)
            {
                await _serviceProject.DeleteAsync(item);
            }

            await _serviceProject.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
