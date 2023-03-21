using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Http;
using FirstMVCApp.ViewModels;

namespace FirstMVCApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _membersrepository;
        public ActionResult DetailsWithCodeSnippets(Guid Id)
        {
           MembercodeSnippetViewModel viewModel =_membersrepository.GetMemberCodeSnippets(Id);
            return View("DetailsWithCodeSnippets",viewModel);
        }
        public MembersController(MembersRepository membersRepository)
        {
            _membersrepository = membersRepository;
        }
        public IActionResult Index()
        {
            var members = _membersrepository.GetMembers();
            return View("Index", members);

        }
        public IActionResult Details(Guid id)//Get
        {
            MemberModel member = _membersrepository.GetMemberById(id);
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
                MemberModel member = new MemberModel();
                TryUpdateModelAsync(member);// se mmappeaza datele din formular pee modelul member
                _membersrepository.AddMember(member);
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult Edit(Guid id)
            {
                MemberModel member = _membersrepository.GetMemberById(id);
                return View("Edit", member);
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
                MemberModel memberModel = new MemberModel();
                TryUpdateModelAsync(memberModel);
                _membersrepository.UpdateMember(memberModel);
                return RedirectToAction("Index");

            }
            public ActionResult Delete(Guid id)
            {
                MemberModel memberModel = _membersrepository.GetMemberById(id);
                return View("Delete", memberModel);
            }

            // POST: CodeSnippetsController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(Guid id, IFormCollection collection)
            {
                _membersrepository.DeleteMember(id);
                return RedirectToAction("Index");
            }

        }
    }