using FirstMVCApp.DataContext;
using Microsoft.EntityFrameworkCore;
using FirstMVCApp.Models;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {
        private readonly ClubDataContext _context;
        public MembershipsRepository(ClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipModel> GetMemberships()
        {
            return _context.Memberships;
        }
        //apoi trebuie sa adaugam metodele CRUD
        public MembershipModel GetMembershipById(Guid id)
        {
            MembershipModel membershipModel = _context.Memberships.FirstOrDefault(x => x.IDMembership == id);
            return membershipModel;
        }
        public void AddMembership(MembershipModel membershipModel)
        {
            membershipModel.IDMembership = Guid.NewGuid();
            _context.Entry(membershipModel).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateMembership(MembershipModel membershipModel)
        {
            _context.Memberships.Update(membershipModel);
            _context.SaveChanges();
        }
        public void DeleteMemberships(Guid id)
        {
            MembershipModel membershipModel = GetMembershipById(id);
            _context.Memberships.Remove(membershipModel);
            _context.SaveChanges();
        }
    }
}
