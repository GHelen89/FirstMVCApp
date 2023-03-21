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
        public void Add (AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid();//setam Id-ul
            _context.Announcements.Add(model);// adaugam modelul in layerul ORM(ClubDataContext)
            _context.SaveChanges();//commit to database
        }
        public AnnouncementModel GetAnnouncemntById(Guid Id)
        {
            AnnouncementModel announcement =_context.Announcements.FirstOrDefault(x => x.IdAnnouncement == Id);
            return announcement;
        }
        public void Update(AnnouncementModel model)
        {
            _context.Announcements.Update(model);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            AnnouncementModel announcement = GetAnnouncemntById(id);
            _context.Announcements.Remove(announcement);
            _context.SaveChanges();
        }
    }
}
