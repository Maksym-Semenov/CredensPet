using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class AddressProjectsController : Controller
    {
        private readonly IService<AddressProjectDTO> _serviceAddressProject;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public AddressProjectsController(IService<AddressProjectDTO> serviceAddressProject)
        {
            _serviceAddressProject = serviceAddressProject;
            _mapperToView = GenericMapperConfiguration<AddressProjectDTO, AddressProjectViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<AddressProjectViewModel, AddressProjectDTO>.MapTo();
        }

        // GET: ContactProjects
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<AddressProjectViewModel>(_serviceAddressProject.FindAll().AsNoTracking());
              return item != null ? 
                          View(item) :
                          Problem("Entity set 'CredensTestContext.Contacts'  is null.");
        }

        // GET: AddressProjects/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            var item = _mapperToView.Map<AddressProjectViewModel>(await _serviceAddressProject.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            return View(item);
        }

        // GET: AddressProjects/CreateFromProject
        public IActionResult CreateFromProject(int id)
        {
            ViewBag.ProjectId = id;

            return View();
        }

        // POST: AddressProjects/CreateFromProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFromProject([Bind("ProjectId, Country, City, ResidentialComplex, " +
                                                                             "TypeStreet, Street, BuildingNumber, Litera, BuildingPart, " +
                                                                             "Apt, Floor, Created, LastUpdated")] AddressProjectViewModel addressProjectViewModel)
        { 
            if (ModelState.IsValid)
            {
                await _serviceAddressProject.AddAsync(_mapperToDTO.Map<AddressProjectDTO>(addressProjectViewModel));
                await _serviceAddressProject.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Projects");
        }

        // GET: AddressProjects/Update/5
        public async Task<IActionResult> Update(string? id)
        {
            var item = _mapperToView.Map<AddressProjectViewModel>(await _serviceAddressProject.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: AddressProjects/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string? id, [Bind("Id, ProjectId, Country, City, ResidentialComplex, " +
                                                                           "TypeStreet, Street, BuildingNumber, Litera, BuildingPart, " +
                                                                           "Apt, Floor, Created, LastUpdated")] AddressProjectViewModel addressProjectViewModel)
        {
            if (id != addressProjectViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    await _serviceAddressProject.UpdateAsync(_mapperToDTO.Map<AddressProjectDTO>(addressProjectViewModel));
                    await _serviceAddressProject.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: AddressProjects/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            var item = _mapperToView.Map<AddressProjectViewModel>(await _serviceAddressProject.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (id == null || _serviceAddressProject == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: AddressProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (_serviceAddressProject == null)
            {
                return Problem("Entity set 'CredensTestContext.Contacts'  is null.");
            }
            var item = _mapperToDTO.Map<AddressProjectDTO>(await _serviceAddressProject.FindAll()
                .FirstOrDefaultAsync(x => x.Id == id));
            if (item != null)
            {
                await _serviceAddressProject.DeleteAsync(item);
            }

            await _serviceAddressProject.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
