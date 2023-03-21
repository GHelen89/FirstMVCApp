using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    public class MembershipController:Controller
    {
        private readonly MembershipsRepository _membershiprepository;
        public MembershipController(MembershipsRepository repository)
        {
            _membershiprepository = repository;
        }
        public IActionResult Index()
        {
            var membership = _membershiprepository.GetMemberships();
            return View("Index",membership);

        }
        public IActionResult Details(Guid id)//Get
        {
            MembershipModel member = _membershiprepository.GetMembershipById(id);
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
            MembershipModel membership = new MembershipModel();
            TryUpdateModelAsync(membership);// se mmappeaza datele din formular pee modelul member
            _membershiprepository.AddMembership(membership);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MembershipModel membership = _membershiprepository.GetMembershipById(id);
            return View("Edit", membership);
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
            MembershipModel membershipModel = new MembershipModel();
            TryUpdateModelAsync(membershipModel);
            _membershiprepository.UpdateMembership(membershipModel);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(Guid id)
        {
            MembershipModel membershipModel = _membershiprepository.GetMembershipById(id);
            return View("Delete", membershipModel);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _membershiprepository.DeleteMemberships(id);
            return RedirectToAction("Index");
        }
       
    }
}
