using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsTypeRepository
    {
        private readonly ClubDataContext _context;
        public MembershipsTypeRepository(ClubDataContext context)
        {
            _context = context;
        }
        public DbSet<MembershipTypeModel> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }
        //apoi trebuie sa adaugam metodele CRUD
        public MembershipTypeModel GetMembershipTypesById(Guid id)
        {
            MembershipTypeModel membershipTypesModel = _context.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == id);
            return membershipTypesModel;
        }
        public void AddMembershipTypes(MembershipTypeModel membershipTypesModel)
        {
            membershipTypesModel.IDMembershipType = Guid.NewGuid();
            _context.Entry(membershipTypesModel).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateMembershipTypes(MembershipTypeModel membershipTypesModel)
        {
            _context.MembershipTypes.Update(membershipTypesModel);
            _context.SaveChanges();
        }
        public void DeleteMembershipTypes(Guid id)
        {
            MembershipTypeModel membershipTypesModel = GetMembershipTypesById(id);
            _context.MembershipTypes.Remove(membershipTypesModel);
            _context.SaveChanges();
        }
    }
}
