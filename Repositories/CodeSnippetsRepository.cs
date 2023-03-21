using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ClubDataContext _context;
        public CodeSnippetsRepository(ClubDataContext context)
        {
            _context = context;
        }
        public DbSet<CodeSnippetModel> GetCodeSnippets()
        {
            return _context.CodeSnippets;
        }
        //apoi trebuie sa adaugam metodele CRUD
        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            CodeSnippetModel codeSnippetModel = _context.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == id);
            return codeSnippetModel;
        }
        public void AddCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IDCodeSnippet = Guid.NewGuid();
            _context.Entry(codeSnippetModel).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            _context.CodeSnippets.Update(codeSnippetModel);
            _context.SaveChanges();
        }
        public void DeleteCodeSnippet(Guid id)
        {
            CodeSnippetModel codeSnippetModel = GetCodeSnippetById(id);
            _context.CodeSnippets.Remove(codeSnippetModel);
            _context.SaveChanges();
        }
    }
}
