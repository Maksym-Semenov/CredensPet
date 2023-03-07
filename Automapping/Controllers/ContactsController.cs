using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IService<ContactDTO> _service;
        private readonly IMapper _mapperForward;
        private readonly IMapper _mapperBackward;

        public ContactsController(IService<ContactDTO> service)
        {
            _service = service;
            _mapperForward = GenericMapperConfiguration<ContactDTO, ContactViewModel>.MapTo();
            _mapperBackward = GenericMapperConfiguration<ContactDTO, ContactDetailsViewModel>.MapTo();
        }

        // GET: Contacts
        public IActionResult Index()
        {
            var contactDTO = _mapperForward.Map<IEnumerable<ContactViewModel>>(_service.GetAll());
              return contactDTO != null ? 
                          View(contactDTO) :
                          Problem("Entity set 'CredensTestContext.Contacts'  is null.");
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contactDTO = _mapperBackward.Map<ContactDetailsViewModel>(_service.Find(id));
            return View(contactDTO);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ContactId,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                _service.Add(contactDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(contactDTO);
        }

        //// GET: Contacts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _service == null)
        //    {
        //        return NotFound();
        //    }

        //    var contact = await _service(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: Contacts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ContactId,City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] Contact contact)
        //{
        //    if (id != contact.ContactId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _service.Update(contact);
        //            await _service;
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContactExists(contact.ContactId))
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
        //    return View(contact);
        //}

        //// GET: Contacts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _service == null)
        //    {
        //        return NotFound();
        //    }

        //    var contact = await _service(m => m.ContactId == id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contact);
        //}

        //// POST: Contacts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_service == null)
        //    {
        //        return Problem("Entity set 'CredensTestContext.Contacts'  is null.");
        //    }
        //    var contact = await _service(id);
        //    if (contact != null)
        //    {
        //        _service.Delete(contact);
        //    }

        //    await _service;
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ContactExists(int id)
        //{
        //  return (_service? (e => e.ContactId == id)).GetValueOrDefault();
        //}
    }
}
