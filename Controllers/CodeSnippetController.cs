using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetController : Controller
    {
        private readonly CodeSnippetRepository _Repository;
        public CodeSnippetController(CodeSnippetRepository repository)
        {
            _Repository = repository;
        }

        public IActionResult Index()
        {
            var codesnippets=_Repository.GetCodeSnippets();
            return View("Index",codesnippets);
        }
    }
}
