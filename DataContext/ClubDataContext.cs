using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.DataContext
{
    public class ClubDataContext:DbContext
    {
        public ClubDataContext(DbContextOptions<ClubDataContext> options) : base(options) { }
        public DbSet<AnnouncementModel> Announcements { get; set; }
        public DbSet<MemberModel> Members {get;set;}
        public DbSet<MembershipModel> Memberships { get; set; }
        public DbSet<CodeSnippetModel> CodeSnippets { get; set; }
        public DbSet<MembershipTypeModel> MembershipTypes { get; set; }
    }
}
