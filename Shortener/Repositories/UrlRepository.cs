using Microsoft.EntityFrameworkCore;
using Shortener.Areas.Identity.Data;
using Shortener.Data;
using Shortener.Interfaces;
using Shortener.Models;
using System.Diagnostics.Metrics;

namespace Shortener.Repositories
{
    public class UrlRepository: GenericRepository<UrlModel>,IUrlRepository
    {
        public UrlRepository(ShortenerDBContext context) : base(context) { }

        public IEnumerable<UrlModel> GetUserUrls(ShortenerUser user)
        {
            return context.Urls
                .Include(u=>u.CreatedBy)
                .Where(u=>u.CreatedBy.Id == user.Id);
        }
        public IEnumerable<UrlModel> GetUserUrlsByEmail(string email)
        {
            return context.Urls
                .Include(u => u.CreatedBy)
                .Where(u => u.CreatedBy.Email == email);
        }


    }
}
