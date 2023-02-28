using AutoMapper;
using Automapping.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using Presentation.ViewModels;

namespace Automapping.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IRepository<Project> _context;
        public ProjectsController(IRepository<Project> context)
        {
            _context = context;
        }

        //public ProjectsController(CredensTestContext context)
        //{
        //    _context = context;
        //}

        // GET: Projects
        public async Task<IActionResult> Index()
        {

            //var mapperConfiguration = new MapperConfiguration(x =>
            //{
            //    x.AddProfile<ProjectMapperConfiguration>();
            //});
            var mapperConfiguration = new MapperConfiguration(cgf =>
                cgf.CreateMap<Project, ProjectViewModel>()
                    .ForMember(x => x.FioDesigner,
                        o 
                            =>  o.Ignore()));
                

            mapperConfiguration.AssertConfigurationIsValid();

            var mapper = new Mapper(mapperConfiguration);
            var project = mapper.Map<IEnumerable<ProjectViewModel>>(_context.GetAll());
            return View(project);
            //return _context.Projects != null ? 
            //              View(await _context.Projects.ToListAsync()) :
            //              Problem("Entity set 'CredensTestContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        //public async Task<IActionResult> Details(int? id)
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

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProjectId,OrderValue,OrderMonth,OrderYear,CustomerId,OrderName,Price,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Litera,BuildingPart,Apartment,Floor,ManagerId,MakerId,BranchId")] Project project)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(project);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(project);
        //}

        // GET: Projects/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Projects == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects.FindAsync(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(project);
        //}

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProjectId,OrderValue,OrderMonth,OrderYear,CustomerId,OrderName,Price,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Litera,BuildingPart,Apartment,Floor,ManagerId,MakerId,BranchId")] Project project)
        //{
        //    if (id != project.ProjectId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(project);
        //            await _context.SaveChangesAsync();
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
        //  return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        //}
    }
}
