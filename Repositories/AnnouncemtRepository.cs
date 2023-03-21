using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
    // clase repository sunt clase care implemeneaza operatiile CRUD pe baze de date
{
    public class AnnouncementsRepository
    {
        private readonly ClubDataContext _context;
        public AnnouncementsRepository (ClubDataContext context)
        {
            _context = context; 
        }
        public DbSet<AnnouncementModel> GetAnnouncements()
        {
            return _context.Announcements;
        }
    }
}
