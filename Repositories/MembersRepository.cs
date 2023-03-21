using FirstMVCApp.DataContext;
using Microsoft.EntityFrameworkCore;
using FirstMVCApp.Models;
using FirstMVCApp.ViewModels;

namespace FirstMVCApp.Repositories
{
    public class MembersRepository
    {
        public MembercodeSnippetViewModel GetMemberCodeSnippets(Guid memberID)
        {
            MembercodeSnippetViewModel membercodeSnippetViewModel = new MembercodeSnippetViewModel();
            MemberModel member = _context.Members.FirstOrDefault(x => x.IDMember == memberID);
            if(member != null)
            {
                membercodeSnippetViewModel.Name = member.Name;
                membercodeSnippetViewModel.Position = member.Position;
                membercodeSnippetViewModel.Title = member.Title;
                IQueryable<CodeSnippetModel> memberCodeSnippets = _context.CodeSnippets.Where(x => x.IDMember == memberID);
                foreach(CodeSnippetModel dbCodeSnippet in memberCodeSnippets)
                {
                    membercodeSnippetViewModel.CodeSnippets.Add(dbCodeSnippet);
                }
            }
            return membercodeSnippetViewModel;
        }
        private readonly ClubDataContext _context;
        public MembersRepository(ClubDataContext context)
        {
            _context = context;
        }
       public DbSet<MemberModel> GetMembers()
        {
            return _context.Members; 
        }
        public MemberModel GetMemberById(Guid id)
        {
            MemberModel memberModel = _context.Members.FirstOrDefault(x => x.IDMember == id);
            return memberModel;
        }
        public void AddMember(MemberModel memberModel)
        {
            memberModel.IDMember = Guid.NewGuid();
            _context.Entry(memberModel).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateMember(MemberModel memberModel)
        {
            _context.Members.Update(memberModel);
            _context.SaveChanges();
        }
        public void DeleteMember(Guid id)
        {
            MemberModel memberModel = GetMemberById(id);
            _context.Members.Remove(memberModel);
            _context.SaveChanges();
        }
    }
}
