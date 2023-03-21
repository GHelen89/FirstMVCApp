using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Http;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _codeSnippetsRepository;
        private readonly MembersRepository _membersRepository;
        public CodeSnippetsController(CodeSnippetsRepository codeSnippetsRepository, MembersRepository membersRepository)
        {
            _codeSnippetsRepository = codeSnippetsRepository;
            _membersRepository = membersRepository;
           
        }

        public IActionResult Index()//get Codesniipetcontrolller
        {
            var codesnippets = _codeSnippetsRepository.GetCodeSnippets();
            return View("Index",codesnippets);
        }
        public IActionResult Details(Guid id)//Get
        {
             CodeSnippetModel codeSnippet = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Details",codeSnippet);
        }
        public IActionResult Create()
        { 
            var members = _membersRepository.GetMembers();
            ViewBag.data = members;
            return View("Create"); //get codesnippet controller create
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            TryUpdateModelAsync(codeSnippetModel);//mapam formularul pe model
            _codeSnippetsRepository.AddCodeSnippet(codeSnippetModel);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Edit",codeSnippetModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,IFormCollection collection)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            TryUpdateModelAsync(codeSnippetModel);
            _codeSnippetsRepository.UpdateCodeSnippet(codeSnippetModel);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View("Delete", codeSnippetModel);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _codeSnippetsRepository.DeleteCodeSnippet(id);
            return RedirectToAction("Index");
        }
    }
}
