using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IService<ProjectDTO> _service;
        private readonly IMapper _mapperForward;
        private readonly IMapper _mapperBackward;
        public ProjectsController(IService<ProjectDTO> service)
        {
            _service = service;
            _mapperForward = GenericMapperConfiguration<ProjectDTO, ProjectViewModel>.MapTo();
            _mapperBackward = GenericMapperConfiguration<ProjectDTO, ProjectDetailsViewModel>.MapTo();
        }

        // GET: Projects
        public IActionResult Index()
        {
            var projectDTO = _mapperForward.Map<IEnumerable<ProjectViewModel>>(_service.GetAll());
            return projectDTO != null ? 
                View(projectDTO) : 
                Problem("Entity set 'CredensTestContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var projectDTO = _mapperBackward.Map<ProjectDetailsViewModel>(_service.Find(id));
            return View(projectDTO);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProjectId,OrderValue,OrderMonth,OrderYear,OrderName,Price,City")] ProjectDTO projectDTO)
        {
            
            if (ModelState.IsValid)
            {
                _service.Add(projectDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(projectDTO);
        }

        //// GET: Projects/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _service == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _service.Find(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(project);
        //}

        // POST: Projects/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProjectId,OrderValue,OrderMonth,OrderYear,CustomerId,OrderName,Price,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Litera,BuildingPart,Apartment,Floor,ManagerId,MakerId,BranchId")] ProjectDTO project)
        //{
        //    if (id != project.ProjectId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _service.Update(project);
        //            await _service.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectExists(project.ProjectId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(project);
        //}

        // GET: Projects/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Projects == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects
        //        .FirstOrDefaultAsync(m => m.ProjectId == id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(project);
        //}

        // POST: Projects/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Projects == null)
        //    {
        //        return Problem("Entity set 'CredensTestContext.Projects'  is null.");
        //    }
        //    var project = await _context.Projects.FindAsync(id);
        //    if (project != null)
        //    {
        //        _context.Projects.Remove(project);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProjectExists(int id)
        //{
        //    return (_service?.GetAll().Where(e => e.ProjectId == id);
        //}
    }
}
