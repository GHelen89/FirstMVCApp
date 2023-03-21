using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipsTypeRepository _membershipTypesrepository;
        public MembershipTypesController(MembershipsTypeRepository repository)
        {
            _membershipTypesrepository = repository;
        }

        public IActionResult Index()
        {
            var membershiptypes = _membershipTypesrepository.GetMembershipTypes();
            return View("Index",membershiptypes);
        }
        public IActionResult Details(Guid id)//Get
        {
            MembershipTypeModel member = _membershipTypesrepository.GetMembershipTypesById(id);
            return View("Details", member);
        }

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            MembershipTypeModel MembershipTypes = new MembershipTypeModel();
            TryUpdateModelAsync(MembershipTypes);// se mmappeaza datele din formular pee modelul member
            _membershipTypesrepository.AddMembershipTypes(MembershipTypes);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MembershipTypeModel MembershipTypes = _membershipTypesrepository.GetMembershipTypesById(id);
            return View("Edit", MembershipTypes);
        }
        /*           [HttpPost]
                    public IActionResult Edit(Guid id, IFormCollection collecttion)
                    {
                        MemberModel member = new();
                        TryUpdateModelAsync(member);
                        _membersrepository.UpdateMember(member);
                        return RedirectToAction("Index");

                    }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipTypeModel MembershipTypesModel = new MembershipTypeModel();
            TryUpdateModelAsync(MembershipTypesModel);
            _membershipTypesrepository.UpdateMembershipTypes(MembershipTypesModel);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(Guid id)
        {
            MembershipTypeModel MembershipTypesModel = _membershipTypesrepository.GetMembershipTypesById(id);
            return View("Delete", MembershipTypesModel);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _membershipTypesrepository.DeleteMembershipTypes(id);
            return RedirectToAction("Index");
        }
    }
}
